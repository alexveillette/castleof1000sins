using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	Camera myCamera;
	public float camSpeed = 0.1f;


	void Start () {
	
		myCamera = GetComponent<Camera>();
	}
	

	void Update () {
		myCamera.orthographicSize = (Screen.height / 100f) / 4f;

		if (target != null) {
			transform.position = Vector3.Lerp(transform.position, target.position, camSpeed) + new Vector3(0, 0, -10);
		}
	}
}
