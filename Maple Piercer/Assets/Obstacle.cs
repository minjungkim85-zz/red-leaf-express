using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float damageAmount =20;
	public bool isDestroyable = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.35f, 1) * 20, ForceMode2D.Impulse);
	}

	void Destroy(){
		if(isDestroyable) StartCoroutine("DelayedDestroy");
	}

	IEnumerator DelayedDestroy(){
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}
}
