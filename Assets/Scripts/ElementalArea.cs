using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalArea : Elemental
{
	[SerializeField] bool startIgnited;
	[SerializeField] bool startFrozen;

	private string curElement;

	// Use this for initialization
	void Start () {
		if (startIgnited)
			ignite();
		else if (startFrozen)
			freeze();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		/*if (other is IElemental)*/
		if (other.gameObject.GetComponent<Orb> () != null) {
			Orb orb = other.gameObject.GetComponent<Orb> ();
			if (curElement == Element.fire) {
				orb.ignite();
			} else if (curElement == Element.ice) {
				orb.freeze();
			}
		}
	}

	override public void ignite ()
	{
		curElement = Element.fire;
	}

	 override public void freeze ()
	{
		curElement = Element.ice;
	}

	public void revert ()
	{
		curElement = null;
	}
}
