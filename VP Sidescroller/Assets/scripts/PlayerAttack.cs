using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {


    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatisEnemies;
    public int damage;
    private bool attack;
    private bool flipped;

    Animator anim;
    Rigidbody2D rigid;
    private SpriteRenderer mySpriteRenderer;

    //public int damage
    // Use this for initialization
    void Start () {

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        flipped = false;
	}
	
    private void HandleAttacks()
    {
        if(attack)
        {
            anim.SetTrigger("attack");
            anim.SetBool("Attack", true);
            rigid.velocity = Vector2.zero;
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
            //anim.SetFloat("Speed", 0);
        }

    }

    private void FlipHitbox()
    {
        if (mySpriteRenderer.flipX == true && attackPos.position.x < 0) //if moving right
            attackPos.position *= -1;
        else if (mySpriteRenderer == false && attackPos.position.x > 0) // if moving left
            attackPos.position *= -1;
    }
	// Update is called once per frame
	void Update () {
        HandleInput();
        if (mySpriteRenderer.flipX == true && attackPos.position.x < 0 && flipped == true)
        {
            attackPos.position *= -1;
            flipped = false;
        }
        else if (mySpriteRenderer == false && attackPos.position.x > 0 && flipped == false) // if moving left
        {
            attackPos.position *= -1;
            flipped = true;
        }
    }

    void FixedUpdate()
    {
        HandleAttacks();
        ResetValues();
    }

    private void ResetValues()
    {
        attack = false;
        anim.SetBool("Attack", false);
        //anim.SetFloat("Speed")
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
