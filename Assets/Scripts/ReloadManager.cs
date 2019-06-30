using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadManager : MonoBehaviour
{
    public static float startPistolAmmo = 30f;
   public float pistolAmmo;

    public static float startRifleAmmo = 30f;
    public float rifleAmmo;

    public static float startSniperAmmo = 30f;
    public float sniperAmmo;


    public static float startHeavyAmmo = 30f;
    public float heavyAmmo;



    public Text ammoText;

    private bool isReloadable = false;


    private void Start()
    {
        pistolAmmo = startPistolAmmo;
        rifleAmmo = startRifleAmmo;
        sniperAmmo = startSniperAmmo;
        heavyAmmo = startHeavyAmmo;



    }



    private void Update()
    {

        if(pistolAmmo < 30 || rifleAmmo < 30 || sniperAmmo < 30 || heavyAmmo < 30)
        {

            isReloadable = true;


        }


        if(isReloadable && Input.GetKey(KeyCode.R))
        {







        }





    }


}
