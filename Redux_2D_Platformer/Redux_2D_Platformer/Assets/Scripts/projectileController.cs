using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    public float projectileSpeed;

    Rigidbody2D myRB;


	// Use this for initialization
	void Awake ()
    {
        myRB = GetComponent<Rigidbody2D>();

        //Applies force the moment projectile rigidbody awakens. Direction of force is determined by projectile transform.

        if (transform.localRotation.z>0)
        {
            myRB.AddForce(new Vector2(-1, 0) * projectileSpeed, ForceMode2D.Impulse);
        }
        else
        {
            myRB.AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse);
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Function used to stop objects affected by force.
    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }


}
