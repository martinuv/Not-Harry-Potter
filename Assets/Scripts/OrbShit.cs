using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbShit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 stuff = gameObject.transform.position;
		Vector2 moreStuff = mouseWorldPos - stuff;

		moreStuff.Normalize();
		rb.AddForce (moreStuff * 500);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
