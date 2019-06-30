using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public Slider healthBar;
    public Text moneyText;


    public static int money;
    public static int health;
    public int startHealth = 100;
    public int startMoney = 1000;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        money = startMoney;
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyText != null)
        
        {
            moneyText.text = "$" + money;
        }

        if (healthBar != null)
        {
            healthBar.value = health;
        }





    }



}
