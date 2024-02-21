using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingLandscape : MonoBehaviour {


    public float backgroundSize;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;

	// Use this for initialization
	void Start ()

    {
        cameraTransform = Camera.main.transform;
        layers = new Transform[cameraTransform.childCount];
        for (int i = 0; i < cameraTransform.childCount; i++)
            layers[i] = cameraTransform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;


	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            ScrollLeft();
        if (cameraTransform.position.x < (layers[rightIndex].transform.position.x + viewZone))
            ScrollRight();
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex--;
        if (leftIndex == layers.Length)
            leftIndex = 0;

    }
	

}
