using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    // MOVEMENT VARIABLES
    public float maxSpeed;                  //Adjusted in Unity

    // JUMPING VARIABLES
    bool grounded = false;
    float groundCheckRadius = 0.2f;         // Used to checks if player touches the ground by overlapping the radius
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;

    bool facingRight;

    // SHOOTING VARIABLES
    public Transform gunTip;
    public GameObject projectile;
    float fireRate = 0.5f;                      // How many bullets can be fired per time
    float nextFire = 0f;                        // How long is the pause between firing bullets

	// Use this for initialization
	void Start ()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
	}

    // Update is called once per frame
    void Update()
    {
        // Player Jumping
        if(grounded && Input.GetAxis("Jump")>0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }


        // Player Shooting
        if (Input.GetAxisRaw("Fire1") > 0) fireProjectile();        // If player presses left mouse key, the game executes 'fireprojectile' function (seen below in script).
    }


    void FixedUpdate ()
    {
        // Check if player is grounded, if not, player is falling
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);


        float move = Input.GetAxis("Horizontal");                                       // Axis are predetermined values in Unity Engine. Axis is associated with button inputs. Imagine UE4 pre-built input settings.
        myAnim.SetFloat("speed",Mathf.Abs(move));                                       // Plays player run animation

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);


        // CHARACTER SPRITE FLIPPING
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
	}
   
    // FLIP FUNCTION
    void flip()
    {
        facingRight = !facingRight;                             //Reverses the current state from true-to-false or false-to-true.

        Vector3 theScale = transform.localScale;                // Actual transformer that transforms the sprite based on given values to flip horizontal direction.
        theScale.x *= -1;                                       // Reversed values
        transform.localScale = theScale;                        // Put in transform
    }


    // FIRE PROJECTILE (SHOOTING)
    void fireProjectile()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            // PROJECTILE DIRECTION AND SPAWN POSITION
            if(facingRight)
            {
                Instantiate(projectile, gunTip.position, Quaternion.Euler(new Vector3(0,0,0)));
            }
            else if(!facingRight)
            {
                Instantiate(projectile, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }


        }
    }
}
