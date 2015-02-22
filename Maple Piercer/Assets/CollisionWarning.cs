using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollisionWarning : MonoBehaviour {
	public TrainEngine engine;
	Image image;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(engine.collisionIncoming && image.enabled == false ) image.enabled = true;
		else if(engine.collisionIncoming == false && image.enabled) image.enabled = false;

	}
}
