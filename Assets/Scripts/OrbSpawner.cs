using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
	[SerializeField] GameObject orb;
	
	void FixedUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Instantiate (orb, gameObject.transform);
		}
	}
}
