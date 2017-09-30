using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
	[Header("Sprites")]
	[SerializeField] Sprite fire;
	[SerializeField] Sprite ice;
	[SerializeField] Sprite inert;

	private Rigidbody2D rb2d;
	private string element;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();

		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 localPos = gameObject.transform.position;
		Vector2 localToMouse = mouseWorldPos - localPos;

		localToMouse.Normalize();
		rb2d.AddForce (localToMouse * 500);
	}

	void FixedUpdate ()
	{
		if (transform.position.y < -100)
		{
			rb2d.isKinematic = true;
			rb2d.velocity = new Vector2();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		/*if (other.gameObject is IElemental)
		{
			
		}*/
		print("Triggered");
	}

	public void ChangeElement (string newElement)
	{
		element = newElement;

		switch (element)
		{
		case ("Fire"):
			ignite();
			break;
		case ("Ice"):
			freeze();
			break;
		default:
			Debug.LogError("Unexpected element encountered");
			element = "Inert";
			revert();
			break;
		}
	}

	private void ignite ()
	{
		
	}

	private void freeze ()
	{
		//change material to slide
	}

	private void revert ()
	{

	}
}
