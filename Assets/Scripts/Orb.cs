using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : Elemental
{
	[Header("Sprites")]
	[SerializeField] Sprite fire;
	[SerializeField] Sprite ice;
	[SerializeField] Sprite inert;

	private string curElement;
	private Rigidbody2D rb2d;
	private SpriteRenderer sr;

	void Awake ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

	void Start ()
	{
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 localPos = gameObject.transform.position;
		Vector2 localToMouse = mouseWorldPos - localPos;

		localToMouse.Normalize();
        rb2d.velocity = localToMouse * 5;
		//rb2d.AddForce (localToMouse * 500);
	}

	void FixedUpdate ()
	{
		if (transform.position.y < CameraController.getLowerBound() - 10)
		{
            OrbSpawner.orbs.Remove(this);
            Destroy(gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		
	}

	override public void Ignite ()
	{
		sr.sprite = fire;
		curElement = Element.fire;
	}

	override public void Freeze ()
	{
		sr.sprite = ice;
		curElement = Element.ice;
		//change material to slide
	}

	public void revert ()
	{
		sr.sprite = inert;
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		/*if (other is IElemental)*/

		if (other.gameObject.GetComponent<Elemental>()) {
			Elemental elemental = other.gameObject.GetComponent<Elemental> ();
			if (curElement == Element.fire) {
				elemental.Ignite ();
			} else if (curElement == Element.ice) {
				elemental.Freeze ();
			}
		}
        OrbSpawner.orbs.Remove(this);
        Destroy(gameObject);
    }
}
