using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject _player;
	public float upperBound;
	public float lowerBound;
	public float leftBound;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 destVec = _player.transform.position;
		destVec.x = Mathf.Max (_player.transform.position.x, leftBound);
		destVec.y = Mathf.Max (lowerBound,Mathf.Min(upperBound,_player.transform.position.y));
		destVec.z = -10.0f;
		transform.position = destVec;

	}
}
