using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform target;
	public bool forwardPanMode = false;
	float defaultCameraSize = 5;
	float currentCameraSize = 5;

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;

	Camera cam;
	public TrainEngine engine;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
		defaultCameraSize = currentCameraSize = cam.orthographicSize;
		originPosition = transform.position;
		originRotation = transform.rotation;
//		shake_intensity = .3f;
//		shake_decay = 0.002f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v =  Vector3.Lerp (transform.position, target.transform.position, 0.99f);
		if(forwardPanMode) v.x += cam.orthographicSize;
		v.y = transform.position.y;
		v.z = -10;
		transform.position = v;
		currentCameraSize -= Input.GetAxis ("Mouse ScrollWheel");
		if(currentCameraSize < 1) currentCameraSize = 1;
		cam.orthographicSize = currentCameraSize;
		shake_intensity = engine.rigidbody.velocity.x / 1000f;
		if (shake_intensity > 0){
			transform.position = transform.position + Random.insideUnitSphere * shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .05f,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .05f,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .05f,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .05f);
			shake_intensity -= shake_decay;

		}

		if(transform.position.y >= -2.02f || transform.position.y <= -2.12f ) transform.position = new Vector3(transform.position.x, -2.02f, transform.position.z);

	}

	void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
				shake_intensity = .3f;
		shake_decay = 0.002f;
	}


}
