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
	public float damage;
	public float maxSpeed = 200;
	public float accelerationRate = 2000;
	float holdTime = 0;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	void Update(){
		if (accelerate) {
			holdTime += Time.deltaTime;

		} else {
			holdTime -= Time.deltaTime;
		}
		holdTime = Mathf.Clamp01 (holdTime);


	}
	bool accelerate = false;
	void Accelerate(bool active){
//		if(active)
		Debug.Log ("Setting accelerate to " + active);
		accelerate = active;
	}
	bool brake = false;
	void Brake(bool active){
		Debug.Log ("Setting brake to " + active);
		brake = active;
	}

	void FixedUpdate(){
//		if(countUp)	t += Time.deltaTime;
//		else t -= Time.deltaTime;
//		rigidbody.AddForce (Vector2.Lerp(Vector2.up * 974, Vector2.up * 980, t));
//		if (countUp && t >= 1) countUp = false;
//		else if(countUp == false && t <= 0) countUp = true;

		if(isEngine && accelerate) rigidbody.AddForce(Vector2.right * acceleration.Evaluate(holdTime) * accelerationRate);
		if(rigidbody.velocity.x > maxSpeed) rigidbody.velocity = new Vector2(maxSpeed, rigidbody.velocity.y); 
		if (isEngine && brake) rigidbody.drag += Time.deltaTime;
		else rigidbody.drag -= Time.deltaTime;
		if(rigidbody.drag < 0) rigidbody.drag =0;
		if(rigidbody.drag > 10) rigidbody.drag =10;
		if(isEngine) CheckFront ();
	}


	void OnCollisionEnter2D(Collision2D collide){
		if(collide.collider.attachedRigidbody){
			collide.collider.attachedRigidbody.AddForce (impactDir * 4, ForceMode2D.Impulse);
			collide.collider.attachedRigidbody.AddTorque(5, ForceMode2D.Impulse);
			if(collide.collider.GetComponent<Obstacle>() != null){
				float accel = acceleration.Evaluate(holdTime) - acceleration.Evaluate(holdTime - Time.deltaTime);
				this.damage += collide.collider.GetComponent<Obstacle>().damageAmount * accel * 10;
				collide.collider.SendMessage("Destroy", SendMessageOptions.DontRequireReceiver);
			}
				
		}
			

	}
	public bool collisionIncoming = false;
	public float collisionCheckDist = 40;
	void CheckFront(){
		RaycastHit2D rh = Physics2D.Raycast (transform.position, Vector2.right, Mathf.Max (10, rigidbody.velocity.x * 2), 1 << LayerMask.NameToLayer ("Obstacle"));
		collisionIncoming = rh.collider != null;
	}
}
