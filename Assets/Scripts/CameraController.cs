using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] GameObject _player;
	[SerializeField] float upperBound;
	[SerializeField] float lowerBound;
	[SerializeField] float leftBound;

	private static CameraController camControl;

    void Awake ()
    {
		camControl = this;
	}

	void Update ()
    {
		Vector3 destVec = _player.transform.position;
		destVec.x = Mathf.Max (_player.transform.position.x, leftBound);
		destVec.y = Mathf.Max (lowerBound,Mathf.Min(upperBound,_player.transform.position.y));
		destVec.z = -10.0f;
		transform.position = destVec;
	}

	public static float GetLowerBound()
    {
		return camControl.lowerBound;
	}
}
