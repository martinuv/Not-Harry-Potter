using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed=10f;
	bool facingRight = true;
	Animator anim;
	private Rigidbody2D rbg;
	void Start()
	{
		anim = GetComponent<Animator> ();
		rbg = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rbg.velocity = new Vector2 (move * maxSpeed, rbg.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
