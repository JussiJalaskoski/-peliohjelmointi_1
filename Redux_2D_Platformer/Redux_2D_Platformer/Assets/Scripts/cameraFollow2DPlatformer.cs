using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour {

    public Transform target;                                // target = whatever camera is following
    public float smoothing;                                 // Camera dampening effect

    Vector3 offset;

    float lowY;                                             // Lowest point camera can go down.

	// Use this for initialization
	void Awake ()
    {
        offset = transform.position - target.position;

        lowY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 targetCamPos = target.position + offset;                                                        // Where camera aims to locate itself (Camera position)

        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);        // Smooth movement to designated camera position

        if (transform.position.y < lowY) transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
	}
}
