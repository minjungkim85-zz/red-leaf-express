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

	void LateUpdate(){

//			Debug.Log (name + ": player is inside!");
		if (Input.GetButtonDown("Submit")) {
			float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
			Debug.Log (name + ": " + dist);
			if(dist < 0.5f){
				Debug.Log ("Sending message " + function);
				target.SendMessage(function, true,SendMessageOptions.DontRequireReceiver);
				playerInside = true;
			}

		}else if(playerInside && Input.GetButtonUp("Submit")){
			target.SendMessage(function, false,SendMessageOptions.DontRequireReceiver);
			playerInside = false;
		}
	}


}
