using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(player.position.x + offset.x, offset.y, offset.z);

    }
	
	// Update is called once per frame
	void Update ()

    {
        if (player.position.x >= -8.4)
        {
            transform.position = new Vector3(player.position.x + offset.x, offset.y, offset.z); // Camera follows the player with specified offset position
        }
    }
}
