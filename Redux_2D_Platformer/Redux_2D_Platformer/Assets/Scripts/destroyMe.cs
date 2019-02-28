using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour {

    public float aliveTime;

	// Use this for initialization
	void Awake ()
    {
        // Destroys object from the game hierarchy based on given time

        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
