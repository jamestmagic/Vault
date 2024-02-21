using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public int numOfHearts;
    private bool off;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    Animator anim;



    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        anim.SetBool("isDead", false);

        off = true;


    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
	
	// Update is called once per frame
	void FixedUpdate () {



        if (health > numOfHearts)
        {
            health = numOfHearts;
        }      
        
        for (int i = 0; i< hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        } 

        if (health == 0 && off)
        {
            anim.SetBool("isDead", true);
            anim.SetTrigger("isDead2");
            off = false;
        }
		
	}
}
