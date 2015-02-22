using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float xMin = -0.43f;
	public float xMax = 0.43f;
	public float speed = 1;
	CameraController cc;
	public bool usePhysics;
	Rigidbody2D rb;
	Animator ani;

	// Use this for initialization
	void Start () {
		cc = Camera.main.GetComponent<CameraController> ();
		rb = GetComponent<Rigidbody2D> ();
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(usePhysics) return;
		Vector3 v = transform.localPosition + Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
//		if(v.x > xMax) cc.forwardPanMode = true;
//		else cc.forwardPanMode = false;
		v.x = Mathf.Clamp (v.x, xMin, xMax);
		transform.localPosition = v;


	}

	void FixedUpdate(){
		if (rb && usePhysics) {
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed,0);
			if(Input.GetAxis("Horizontal") != 0){
				ani.SetFloat("MoveX", Input.GetAxis("Horizontal") );
			}

			ani.SetBool("Walk", Input.GetAxis("Horizontal") > 0);
//			Debug.Log (rb.velocity);
		}
	}
}
