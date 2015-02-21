using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collide){
		if (collide.tag == "Engine") {
			Debug.Log ("Arrived at station");
		}
	}
}
