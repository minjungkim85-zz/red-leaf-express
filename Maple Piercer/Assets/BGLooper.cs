using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	public TrainEngine te;
	public Transform[] bgs;
	public float[] diffs;
	public float speed = 1;
	public float startX;
	public float buffer;
	public float shakeScale;
	// Use this for initialization

	
	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	public float shake_intensity;
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(te.rigidbody.velocity.x) <1 && transform.parent != null) transform.parent = null;
		if(Mathf.Abs(te.rigidbody.velocity.x) >= 1 && transform.parent == null) transform.parent = Camera.main.transform; 
		foreach (Transform t in bgs) {
			t.localPosition += Vector3.left * Time.deltaTime * speed * te.rigidbody.velocity.x;
			if(t.localPosition.x < -18) t.localPosition = new Vector3(startX , t.localPosition.y, t.localPosition.z);
		}

		shake_intensity = te.rigidbody.velocity.x / 1000f;
		if (shake_intensity > 0){
			float y = transform.position.y;
			Vector3 v = transform.position + Random.insideUnitSphere * shake_intensity; 

			v.y = Mathf.Clamp(v.y, -2.45f, -2.27f);
			transform.position = v;

//			transform.rotation = new Quaternion(
//				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .05f,
//				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .05f,
//				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .05f,
//				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .05f);
			shake_intensity -= shake_decay;
			
		}
	}
}
