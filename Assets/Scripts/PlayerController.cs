using UnityEngine;using UnityEngine.SceneManagement;public class PlayerController : MonoBehaviour{    public Sprite jumping;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float jumpForce = 700f;
    public float maxSpeed = 10f;

    private Animator anim;
    private Rigidbody2D rbg;
    private SpriteRenderer spriteRenderer;
	private Vector2 curRespawn;    private bool facingRight = true;	private bool grounded = true;	private float groundRadius = 0.2f;	void Start()	{		curRespawn = transform.position;		anim = GetComponent<Animator> ();		rbg = GetComponent<Rigidbody2D> ();	}	void FixedUpdate ()	{		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);        anim.SetBool ("Ground", grounded);		anim.SetFloat ("vSpeed", rbg.velocity.y);		float move = Input.GetAxis ("Horizontal");
        anim.SetFloat ("Speed", Mathf.Abs (move));		rbg.velocity = new Vector2 (move * maxSpeed, rbg.velocity.y);		if (move > 0 && !facingRight)			Flip ();		else if (move < 0 && facingRight)			Flip ();		if (transform.position.y < CameraController.GetLowerBound() - 10)			Respawn();	}	void Update()	{		if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {			anim.SetBool ("Ground", false);			rbg.AddForce (new Vector2 (0, jumpForce));		}        if (Input.GetKeyDown(KeyCode.R))
            Respawn();	}	void Flip()	{		facingRight = !facingRight;		Vector3 theScale = transform.localScale;		theScale.x *= -1;		transform.localScale = theScale;	}	private void Respawn()	{        SoundController.PlayDeath();        GameManager.LoadScene(SceneManager.GetActiveScene().name);        transform.position = curRespawn;	}	private void OnCollisionEnter2D(Collision2D other)	{		if(other.gameObject.tag == "platform")			transform.SetParent (other.transform); 	}    private void OnCollisionExit2D(Collision2D other)	{		if(other.gameObject.tag == "platform")			transform.SetParent (null);	}    private void OnTriggerEnter2D(Collider2D other)	{		if (other.gameObject.tag == "hazard")			Respawn ();	}    public bool GetFacingRight()    {        return facingRight;    }}