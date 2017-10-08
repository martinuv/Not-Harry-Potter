using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Sprite jumping;

	private Vector2 curRespawn;

	void Start()
	{
		curRespawn = transform.position;
		anim = GetComponent<Animator> ();
		//spriteRenderer = GetComponent <SpriteRenderer> ();
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

		if (transform.position.y < CameraController.GetLowerBound() - 10) {
			Respawn();
		}
	}

	void Update()
	{
		if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) {
			anim.SetBool ("Ground", false);
			rbg.AddForce (new Vector2 (0, jumpForce));
		}

        if (Input.GetKeyDown(KeyCode.R)) {
            Respawn();
        }
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void Respawn()
	{
        SoundController.PlayDeath();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        transform.position = curRespawn;
	}

	public void setRespawn ()
	{
		
	}

	private void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.tag == "platform")
		{
			transform.SetParent (c.transform); 

		}

	}

    private void OnCollisionExit2D(Collision2D d)
	{
		if(d.gameObject.tag == "platform")
		{
			transform.SetParent (null);
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "hazard") {
			Respawn ();
		}
	}

    public bool GetFacingRight()
    {
        return facingRight;
    }
}
