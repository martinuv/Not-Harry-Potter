﻿using UnityEngine;public class Orb : Elemental{	[Header("Sprites")]	[SerializeField] Sprite fire;	[SerializeField] Sprite ice;    [Space]    [SerializeField] float orbVelocity;	private string curElement;	private Rigidbody2D rb2d;	private SpriteRenderer sr;	void Awake ()	{		rb2d = GetComponent<Rigidbody2D>();		sr = GetComponent<SpriteRenderer>();	}	void Start ()	{		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);		Vector2 localPos = gameObject.transform.position;		Vector2 localToMouse = mouseWorldPos - localPos;        if (transform.lossyScale.x > 0 && localToMouse.x < 0)            localToMouse.x *= -1;        else if (transform.lossyScale.x < 0 && localToMouse.x > 0)            localToMouse.x *= -1;        localToMouse.Normalize();        rb2d.velocity = localToMouse * orbVelocity;	}	void FixedUpdate ()	{		if (transform.position.y < CameraController.GetLowerBound() - 10)		{            OrbSpawner.orbs.Remove(this);            Destroy(gameObject);		}	}	override public void Ignite ()	{		sr.sprite = fire;		curElement = Element.fire;        SoundController.PlayWhoosh();	}	override public void Freeze ()	{		sr.sprite = ice;		curElement = Element.ice;        SoundController.PlayFreeze();	}	void OnCollisionEnter2D (Collision2D other)	{		if (other.gameObject.GetComponent<Elemental>())        {			Elemental elemental = other.gameObject.GetComponent<Elemental> ();			if (curElement == Element.fire)				elemental.Ignite ();			else if (curElement == Element.ice)				elemental.Freeze ();		}        OrbSpawner.orbs.Remove(this);        Destroy(gameObject);    }}