using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public float speedParallax;

    private float camareLastPositionX;

    private Transform[] layers;
    private Transform cameraTransform;
    private int leftIndex, rightIndex;
    private float backgroundSize;
    private float viewZone;

   


	// Use this for initialization
	void Start () {
        cameraTransform = GameObject.Find("Main Camera").transform;
        camareLastPositionX = cameraTransform.position.x;

        layers = new Transform[transform.childCount];
        for (int i = 0; i < layers.Length; i++)
            layers[i] = transform.GetChild(i);
        backgroundSize = layers[1].position.x - layers[0].position.x;
        leftIndex = 0;
        rightIndex = layers.Length - 1;

        viewZone = cameraTransform.gameObject.GetComponent<Camera>().orthographicSize * cameraTransform.gameObject.GetComponent<Camera>().aspect;
    }
	
	// Update is called once per frame
	void Update () {
        

        if (cameraTransform.position.x > layers[rightIndex].position.x - viewZone)
            ScrollRight();

        if (cameraTransform.position.x < layers[leftIndex].position.x + viewZone)
            ScrollLeft();
	}

    void FixedUpdate()
    {
        float delta = (cameraTransform.position.x - camareLastPositionX);
        //Parallax
        transform.position += Vector3.right * (delta * speedParallax);
        camareLastPositionX = cameraTransform.position.x;
    }

    private void ScrollLeft()
    {
        layers[rightIndex].position = layers[leftIndex].position - Vector3.right * backgroundSize;
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        layers[leftIndex].position = layers[rightIndex].position + Vector3.right * backgroundSize;
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
