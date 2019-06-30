using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{



public Enemy enemy;
public Transform player;
public GameObject gameMaster;
private PlayerStats playerStats;
  



    float distanceFromPlayer;
    public float lookRange = 30.0f;
    public float agroRange = 5f;
    public float moveSpeed = 6.0f;
    public float damping   = 6.0f;

    public int damageRate = 5;
    // Use this for initialization
    void Start () {

       
        enemy = GetComponent<Enemy>();

        player = GameObject.FindWithTag("Player").transform;

        gameMaster = GameObject.FindWithTag("GameMaster");




    
    }
    
    // Update is called once per frame
    void Update () 
    {
        distanceFromPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceFromPlayer < lookRange ) 
        {
            transform.LookAt(player);
        }

        if (distanceFromPlayer < agroRange) 
        
        {
            Attack();

        }
    }

    void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
         transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
    }

    void Attack ()
    {
        transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);

        PlayerStats.health -= damageRate;

    }
}

