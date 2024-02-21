using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }


    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}