﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
	[SerializeField] Orb orb;

	public static List<Orb> orbs = new List<Orb>(6);

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Orb newOrb = Instantiate (orb, gameObject.transform);
			newOrb.transform.parent = null;

			orbs.Add (newOrb);
			if (orbs.Count > 5) {
				Destroy(orbs[0].gameObject);
				orbs.RemoveAt(0);
			}
		}
	}
}
