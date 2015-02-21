using UnityEngine;
using System.Collections;

public class ControlPanel : MonoBehaviour {
	public Transform target;
	public string function;
	void OnTriggerEnter2D(Collider2D collide){
		if(collide.tag == "Player")
		Debug.Log ("Player's inside me!");
	}

	void OnTriggerStay2D(Collider2D collide){
		if (Input.GetButtonDown("Submit")) {
			target.SendMessage(function, true,SendMessageOptions.DontRequireReceiver);
		}else if(Input.GetButtonUp("Submit")){
			target.SendMessage(function, false,SendMessageOptions.DontRequireReceiver);
		}
	}
}
