using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemySpawner;
    public GameObject enemyPrefab;

    public Enemy enemy;

    private Vector3 EnemySpawn;

    public int enemyCount = 0;
    public int maxEnemies = 5;


    // Start is called before the first frame update
    void Start()

    {

    


    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < maxEnemies)
        {

            SpawnEnemy();


        }







    }


    void SpawnEnemy()
    {

        EnemySpawn = new Vector3(Random.Range(-20, 95), 1, Random.Range(-35, 30));

        Instantiate(enemyPrefab, EnemySpawn, Quaternion.identity);

        enemyCount++;


    }


}
