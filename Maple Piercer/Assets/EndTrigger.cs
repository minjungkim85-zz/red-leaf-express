using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {
	public GameManager gm;
	void OnTriggerEnter2D(Collider2D collide){
		if (collide.tag == "Engine") {
			TrainEngine te = collide.GetComponent<TrainEngine>();
			if(te.rigidbody.velocity.x < 40){
				gm.SendMessage("Victory");
			}
		}
	}
}
