using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour {
	public GameObject orb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

		if (Input.GetMouseButtonDown(0)) {
			Instantiate (orb, gameObject.transform);

		}
	}
}
