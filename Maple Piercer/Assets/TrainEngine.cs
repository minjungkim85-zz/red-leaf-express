using UnityEngine;
using System.Collections;

public class TrainEngine : MonoBehaviour {
	public Rigidbody2D rigidbody;
	float t = 0;
	bool countUp = true;
	public bool isEngine = false;
	public Vector2 impactDir;
	float magnitude = 0;
	public AnimationCurve acceleration;
	float holdTime = 0;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	void Update(){
		if (Input.GetMouseButton (0)) {
			holdTime += Time.deltaTime;

		} else {
			holdTime -= Time.deltaTime;
		}
		holdTime = Mathf.Clamp01 (holdTime);


	}

	void FixedUpdate(){
//		if(countUp)	t += Time.deltaTime;
//		else t -= Time.deltaTime;
//		rigidbody.AddForce (Vector2.Lerp(Vector2.up * 974, Vector2.up * 980, t));
//		if (countUp && t >= 1) countUp = false;
//		else if(countUp == false && t <= 0) countUp = true;

		if(isEngine && Input.GetMouseButton (0)) rigidbody.AddForce(Vector2.right * acceleration.Evaluate(holdTime) * 2000);
		if(rigidbody.velocity.x > 200) rigidbody.velocity = new Vector2(200, rigidbody.velocity.y); 
		if (isEngine && Input.GetMouseButton (1)) rigidbody.drag += Time.deltaTime;
		else rigidbody.drag -= Time.deltaTime;
		if(rigidbody.drag < 0) rigidbody.drag =0;
		if(rigidbody.drag > 10) rigidbody.drag =10;
	}


	void OnCollisionEnter2D(Collision2D collide){
		if(collide.collider.attachedRigidbody)
			collide.collider.attachedRigidbody.AddForce (impactDir * 4, ForceMode2D.Impulse);
	}
}
