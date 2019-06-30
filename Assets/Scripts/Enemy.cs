using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{



    GameObject gameMaster;

    public GameObject enemySpawner;

    private Spawner spawner;


    List<GameObject> prefabList = new List<GameObject>();
    public GameObject pistolAmmoPrefab;
    public GameObject rifleAmmoPrefab;
    public GameObject sniperAmmoPrefab;
    public GameObject heavyAmmoPrefab;
    public GameObject healthpackPrefab;



    public GameObject enemyPrefab;



    public float health = 50f;

    public int worth = 50;

    public int damageRate = 5;

  


    private void Start()
    {
        enemySpawner = GameObject.FindWithTag("Spawner");
        spawner = enemySpawner.GetComponent<Spawner>();





        prefabList.Add(pistolAmmoPrefab);
        prefabList.Add(rifleAmmoPrefab);
        prefabList.Add(sniperAmmoPrefab);
        prefabList.Add(heavyAmmoPrefab);
        prefabList.Add(healthpackPrefab);


       

    }


    private void Update()
    {




    }

    public void TakeDamage (float amount)
    {

        health -= amount;
        if(health <= 0f)
        {


            Die();

        }


    }

    public void Die()
    {

        Destroy(gameObject);

        PlayerStats.money += worth;
        Debug.Log(PlayerStats.money);

        int prefabIndex = UnityEngine.Random.Range(0, 5);

        Instantiate(prefabList[prefabIndex], transform.position, Quaternion.identity);

        spawner.enemyCount--;








    }

   

}
