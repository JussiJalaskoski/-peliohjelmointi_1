using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmaHit : MonoBehaviour {

    public float weaponDamage;

    projectileController myProjectileControl;

    public GameObject impactEffect;


	// Use this for initialization
	void Awake ()
    {
        myProjectileControl = GetComponentInParent<projectileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myProjectileControl.removeForce();
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }

    //Safety check
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myProjectileControl.removeForce();
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
