using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	Image image;
	public TrainEngine engine;
	void Start(){
		image = GetComponent<Image> ();
	}
	// Update is called once per frame
	void Update () {
		image.fillAmount = (100 - engine.damage) / 100;
	}
}
