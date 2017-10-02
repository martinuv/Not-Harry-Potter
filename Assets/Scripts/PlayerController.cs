using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed=10f;
	bool facingRight = true;
	bool grounded = true;
	float groundRadius = 0.2f;
	Animator anim;
	private Rigidbody2D rbg;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float jumpForce = 700f;
	private SpriteRenderer spriteRenderer;
	void Start()
	{
		anim = GetComponent<Animator> ();
		//spriteRenderer = GetComponent < SpriteRenderer> ();
		rbg = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("vSpeed", rbg.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rbg.velocity = new Vector2 (move * maxSpeed, rbg.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}
	void Update()
	{
		
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground", false);
			rbg.AddForce (new Vector2 (0, jumpForce));
		}

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
