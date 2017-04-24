using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour
{

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jump = 150f;

    public bool grounded;

    private Rigidbody2D rb2d;
    private Animator anim;
    

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
      
    }


    void Update()
    {



        

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (grounded == true)
            {
                
                rb2d.AddForce (Vector3.up * jump, ForceMode2D.Impulse);

            }
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded == true)
			{

				rb2d.AddForce (Vector3.up * jump, ForceMode2D.Impulse);

			}
		}


        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
        if (GameObject.Find("Corpse1(Clone)"))
        {
            Destroy(gameObject);
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
    }








    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector3.right * speed * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector3(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector3(-maxSpeed, rb2d.velocity.y);
        }


    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            
        }

    }



}

