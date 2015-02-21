using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float xMin = -0.43f;
	public float xMax = 0.43f;
	CameraController cc;
	// Use this for initialization
	void Start () {
		cc = Camera.main.GetComponent<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = transform.localPosition + Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;
//		if(v.x > xMax) cc.forwardPanMode = true;
//		else cc.forwardPanMode = false;
		v.x = Mathf.Clamp (v.x, xMin, xMax);
		transform.localPosition = v;
	}
}
