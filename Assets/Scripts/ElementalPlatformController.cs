﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalPlatformController : Elemental {
	private string curElement;
	public float speed;
	private float actSpeed=0;
	public float radius;
	public bool horizontal;
	public bool reveseDirection;
	public float _delay;
	private Vector2 _startPos;
	private int direction = 1;
	public bool pause;
	// Use this for initialization
	void Start () {
		_startPos = transform.position;
		if(reveseDirection){
			direction *= -1;
		}
	
		StartCoroutine ("delay");

	}

	// Update is called once per frame
	public void setActSpeed(float speed)
	{
		actSpeed=speed;
	}
	void Update () {
		if (!pause) {
				if (horizontal) {
					Vector3 deltaPos = new Vector3 ();
					deltaPos.x = actSpeed * Time.deltaTime * direction;
					transform.position += deltaPos;
					/*			if(Mathf.Abs(transform.position.x-_startPos.x)>=radius){
					direction *= -1;
				}*/
					if (direction == 1) {
						if (transform.position.x - _startPos.x >= radius) {
							direction = -1;
						}
					} else {
						if (_startPos.x - transform.position.x >= radius) {
							direction = 1;
						}
					}
				} else {
					Vector3 deltaPos = new Vector3 ();
					deltaPos.y = actSpeed * Time.deltaTime * direction;
					transform.position += deltaPos;
					/*			if(Mathf.Abs(transform.position.y-_startPos.y)>=radius){
					direction *= -1;
				}*/
					if (direction == 1) {
						if (transform.position.y - _startPos.y >= radius) {
							direction = -1;
						}
					} else {
						if (_startPos.y - transform.position.y >= radius) {
							direction = 1;
						}
					}

			}
		}
	}
	override public void Ignite ()
	{
		curElement = Element.fire;
		pause = false;
        SoundController.PlayWhoosh();
	}

	override public void Freeze ()
	{
		curElement = Element.ice;
		pause = true;
        SoundController.PlayFreeze();
	}

	IEnumerator delay(){
		yield return new WaitForSeconds (_delay);
		actSpeed = speed;
	}
}
