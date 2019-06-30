using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    public AmmoType ammo;

    private GameObject gameMaster;


    public bool isHealthPack = false;


    private AmmoInventory ammoInventory;
    public float radius = 3f;

    public int ammoAmount = 15;


    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        ammoInventory = gameMaster.GetComponent<AmmoInventory>();

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            Destroy(gameObject);

            if(isHealthPack)
            {


                PlayerStats.health += 20;



            } else
            {

                ammoInventory.Collect(ammo, ammoAmount);

            }


            


        }

    }
}
