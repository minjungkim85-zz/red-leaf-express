using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollisionWarning : MonoBehaviour {
	public TrainEngine engine;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(engine.collisionIncoming && text.enabled == false ) text.enabled = true;
		else if(engine.collisionIncoming == false && text.enabled) text.enabled = false;

	}
}
