using UnityEngine;

public abstract class Elemental : MonoBehaviour
{
	public abstract void Ignite();
	public abstract void Freeze();
}

public static class Element {
	public static readonly string fire = "fire";
	public static readonly string ice = "ice";
}
