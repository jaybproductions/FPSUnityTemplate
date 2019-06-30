using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{


    public Canvas gameoverUI;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {

        gameoverUI.enabled = false;
        player = GameObject.FindWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {


        if(PlayerStats.health <= 0)
        {


            GameOver();


        }
        
    }


    void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameoverUI.enabled = true;


        GameObject.FindWithTag("OverlayUI").SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerMotor>().enabled = false;
        GameObject.FindWithTag("WeaponSlot").SetActive(false);


    }

    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       


    }

    public void MainMenu ()
    {

        SceneManager.LoadScene(0);


    }


    public void Quit()
    {

        Application.Quit();


    }
}
