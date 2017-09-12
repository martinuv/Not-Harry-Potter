// <copyright file="PlayerInputModule2D.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>07/14/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Module for player controller input when using a PlatformController2D. Uses standart Horizontal and Vertical input axis as well as Jump button.
/// </summary>
public class PlayerInputModule2D : MonoBehaviour
{
	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 stuff = gameObject.transform.position;
		Vector2 moreStuff = mouseWorldPos - stuff;
		//rb.AddForce (moreStuff*5);
	}
}
