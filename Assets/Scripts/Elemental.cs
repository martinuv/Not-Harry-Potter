using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Elemental : MonoBehaviour
{
	//private string curElement;

	public abstract void Ignite();
	public abstract void Freeze();
}

public static class Element {
	public static readonly string fire = "fire";
	public static readonly string ice = "ice";
}