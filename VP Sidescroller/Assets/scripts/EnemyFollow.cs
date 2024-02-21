using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    // Use this for initialization
    public float speed;

    Animator anim;

    private Transform target;

    SpriteRenderer slimeSpriteRenderer;

    Rigidbody2D slimeRigidbody;

    private bool tracking;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        slimeRigidbody = GetComponent<Rigidbody2D>();
        slimeSpriteRenderer = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
        tracking = false;
    }

    void Update()
    {
        //anim.SetFloat("Speed", slimeRigidbody.velocity.x);

        if (Vector2.Distance(transform.position, target.position) <= 7)
        {
            tracking = true;   
        }
        if(tracking)
        {
            if (Vector2.Distance(transform.position, target.position) > .75)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        if (target.position.x < transform.position.x && slimeSpriteRenderer.flipX == true)
        {
            slimeSpriteRenderer.flipX = false;
        }
        else if(target.position.x > transform.position.x && slimeSpriteRenderer.flipX == false)
        {
            slimeSpriteRenderer.flipX = true;
        }
    }
}
