using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    // This function is called just one time by Unity the moment the game loads
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // This function is called by Unity every frame
    private void FixedUpdate()
    {
        // if the variable isn't empty (we have a reference to our SpriteRenderer)
        if (mySpriteRenderer != null)
        {
            // if the A key was pressed this frame
            if (Input.GetKeyDown(KeyCode.A))
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
            }
        }
    }
    
}
