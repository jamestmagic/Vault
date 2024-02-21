using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Use this for initialization

    public int health;
    public float speed;
    public bool withinDamageRange;
    public float damageRange;

    Rigidbody2D rigid;

    private Transform target;
    private PlayerHealth playerHealth;

    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        withinDamageRange = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(Vector2.Distance(transform.position, target.position) <= damageRange && withinDamageRange == false)
        {
            Debug.Log("you have been hit");
            playerHealth.health -= 1;
            withinDamageRange = true;
        }
        if (Vector2.Distance(transform.position, target.position) > (damageRange + .5) && withinDamageRange == true)
        {
            withinDamageRange = false;
            Debug.Log("You are now able to be hit");
        }

    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage taken");
    }
}
