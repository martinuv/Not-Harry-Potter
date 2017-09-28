using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbShit : MonoBehaviour
{
	[Header("Sprites")]
	[SerializeField] Sprite fire;
	[SerializeField] Sprite ice;
	[SerializeField] Sprite inert;

	private string element;

	void Start ()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 localPos = gameObject.transform.position;
		Vector2 localToMouse = mouseWorldPos - localPos;

		localToMouse.Normalize();
		rb.AddForce (localToMouse * 500);
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
