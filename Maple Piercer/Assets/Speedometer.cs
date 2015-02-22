using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Speedometer : MonoBehaviour {
	Image image;
	public TrainEngine engine;
	void Start(){
		image = GetComponent<Image> ();
	}
	// Update is called once per frame
	void Update () {
		image.fillAmount = engine.rigidbody.velocity.x / engine.maxSpeed;
	}
}
