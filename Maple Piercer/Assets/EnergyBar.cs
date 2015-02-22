using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyBar : MonoBehaviour {
	Image image;
	public TrainEngine engine;
	void Start(){
		image = GetComponent<Image> ();
	}
	// Update is called once per frame
	void Update () {
		image.fillAmount = engine.energy / 100;
	}
}
