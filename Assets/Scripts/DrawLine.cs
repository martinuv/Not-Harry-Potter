using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
	public float distance;
	void OnDrawGizmos(){
		Gizmos.DrawLine (transform.position - new Vector3 (distance, 0, 0), transform.position + new Vector3 (distance, 0, 0));
		Gizmos.DrawLine (transform.position - new Vector3 (distance, 0.5f, 0), transform.position - new Vector3 (distance, -0.5f, 0));
		Gizmos.DrawLine (transform.position + new Vector3 (distance, 0.5f, 0), transform.position + new Vector3 (distance, -0.5f, 0));
	}
}
