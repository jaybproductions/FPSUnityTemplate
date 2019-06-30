using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Text ammoText;

    private Gun gun;







    // Start is called before the first frame update
    void Start()
    {


        gun = GetComponent<Gun>();
        SelectWeapon();



    }

    // Update is called once per frame
    void Update()
    {
       


        int previousSelectedWeapon = selectedWeapon;


        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= transform.childCount - 1)
            {

                selectedWeapon = 0;


            } else
            {
                selectedWeapon++;


            }



            if(previousSelectedWeapon != selectedWeapon)
            {


                SelectWeapon();
            }



        }



        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;


            }
            else
            {
                selectedWeapon--;


            }



        }



    }


    void SelectWeapon()
    {

        int i = 0;

        foreach (Transform weapon in transform)
        {

            if(i == selectedWeapon)
            {

                weapon.gameObject.SetActive(true);


            } else
            {

                weapon.gameObject.SetActive(false);

            }
            i++;

        }


       
    }



    
}
