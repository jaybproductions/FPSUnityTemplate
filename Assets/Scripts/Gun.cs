using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AmmoType : int
{

    Pistol,
    Rifle,
    Sniper,
    Heavy


}


public class Gun : MonoBehaviour
{

    public Text ammoStock;



    public AmmoType ammo;
    public int ammoPerShot = 1;

    public GameObject gameMaster;
    private AmmoInventory ammoInventory;



    public int speed = 10;
    public int range = 100;
    public int damage = 10;
    public int impactForce = 30;
    public int fireRate = 15;
    public int maxAmmo = 30;
    public int currentAmmo;
    public int differenceBetween;

    public int maxClip = 15;

    public float reloadTime = 1f;

    private bool isReloading = false;

    private bool canReload = false;

    public Animator animator;


    public Text ammoText;


    public Text reloadText;
    

    public GameObject impactEffect;
     
    public ParticleSystem muzzleFlash;



    



    public Camera fpsCam;

    private float nextTimeToFire = 0f;


   


    private void Start()
    { 

        ammoInventory = gameMaster.GetComponent<AmmoInventory>();




        differenceBetween = ammoInventory.GetStock(ammo) - maxAmmo;
        currentAmmo = ammoInventory.GetStock(ammo) - differenceBetween;
        reloadText.enabled = false;
    }



  




    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);



    }


    private void Update()
    {

        ammoText.text = currentAmmo + " / " + maxAmmo;

        if (isReloading)
            return;





            

        if(currentAmmo == maxAmmo)
        {

            canReload = false;


        }

        if(currentAmmo < maxAmmo)
        {

            canReload = true;



        }

       

            ammoStock.text = ammoInventory.GetStock(ammo).ToString();


       



        if (canReload && Input.GetKey(KeyCode.R) && ammoInventory.GetStock(ammo) > 0)
        {

            StartCoroutine(Reload());
            return;




        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            

        }






    }


    void Shoot()
    {
        if (currentAmmo <= 0)
        {

            reloadText.enabled = true;
            return;



        }






        currentAmmo--;
        
       





        RaycastHit hit;
        if (!Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            return;
        }

        Debug.Log(hit.transform.name);

        Enemy enemy = hit.transform.GetComponent<Enemy>();




        muzzleFlash.Play();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);



        }


        if (hit.rigidbody != null)
        {


            hit.rigidbody.AddForce(-hit.normal * impactForce);

        }



        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 1f);






    }




    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading....");

        animator.SetBool("Reloading", true);

       



        reloadText.enabled = false;

        yield return new WaitForSeconds(reloadTime - .25f);


        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        if(ammoInventory.GetStock(ammo) < maxAmmo && currentAmmo == 0)
        {


            currentAmmo = ammoInventory.GetStock(ammo);

            _ = ammoInventory.Spend(ammo, currentAmmo);

            ammoStock.text = 0.ToString();



        }
        else
        {

            _ = ammoInventory.Spend(ammo, maxAmmo + -currentAmmo);



            currentAmmo = maxAmmo;

        }

       


           

        


        if (ammoInventory.GetStock(ammo) < maxAmmo)
        {



        }








        isReloading = false;

    }


    


   

}
