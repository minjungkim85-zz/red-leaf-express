using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float xMin = -0.43f;
	public float xMax = 0.43f;
	public float speed = 1;
	CameraController cc;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		cc = Camera.main.GetComponent<CameraController> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
//	void Update () {
//		Vector3 v = transform.localPosition + Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
////		if(v.x > xMax) cc.forwardPanMode = true;
////		else cc.forwardPanMode = false;
//		v.x = Mathf.Clamp (v.x, xMin, xMax);
//		transform.localPosition = v;
//	}

	void FixedUpdate(){
		if (rb) {
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed,0);
//			Debug.Log (rb.velocity);
		}
	}
}
