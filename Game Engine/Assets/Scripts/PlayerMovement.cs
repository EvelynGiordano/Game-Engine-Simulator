using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public PlayerController controller;
	public Animator anim;

	public float runSpeed = 400f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	bool grounded = true;
	bool dbl = false;

	// Update is called once per frame
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
		

		if (Input.GetButtonDown("Jump"))
		{
            if (grounded && !jump)
            {
				anim.SetBool("Jump", true);
				jump = true;
			} else if (!grounded)
            {
				anim.SetBool("Double Jump", true);
				jump = false;
				dbl = true;
            }
			
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}


	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, dbl);
		jump = false;
		dbl = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		anim.SetBool("Double Jump", false);
		anim.SetBool("Jump", false);
		anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
		grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
		anim.SetFloat("Speed", 0);
		grounded = false;
    }
}
