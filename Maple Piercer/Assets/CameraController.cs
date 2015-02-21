using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform target;
	float defaultCameraSize = 5;
	float currentCameraSize = 5;
	
	Camera cam;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		defaultCameraSize = cam.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v =  Vector3.Lerp (transform.position, target.transform.position, 0.99f);
		v.z = -10;
		transform.position = v;
		currentCameraSize -= Input.GetAxis ("Mouse ScrollWheel");
		if(currentCameraSize < 1) currentCameraSize = 1;
		cam.orthographicSize = currentCameraSize;

	}


}
