using UnityEngine;
using System.Collections;

public class ControlPanel : MonoBehaviour {
	public Transform target;
	public string function;
	bool playerInside = false;
	void OnTriggerEnter2D(Collider2D collide){
		if (collide.tag == "Player")
			playerInside = true;
//		Debug.Log (name +": Player's inside me!");
	}

	void Update(){
		if (playerInside) {
//			Debug.Log (name + ": player is inside!");
			if (Input.GetButtonDown("Submit")) {
				Debug.Log ("Sending message " + function);
				target.SendMessage(function, true,SendMessageOptions.DontRequireReceiver);
			}else if(Input.GetButtonUp("Submit")){
				target.SendMessage(function, false,SendMessageOptions.DontRequireReceiver);
			}
		}

	}

	void OnTriggerExit2D(Collider2D collide){
		if (collide.tag == "Player") { 
			playerInside = false;
			Debug.Log (name +": Player's exited me!");
		}
			

	}
}
