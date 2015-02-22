using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StationWarning : MonoBehaviour {
	public GameManager gm;
	public TrainEngine te;
	Image image;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(gm.displayWarning && image.enabled == false ) image.enabled = true;
		else if(gm.displayWarning == false && image.enabled) image.enabled = false;
		if(te.collisionIncoming && image.enabled == true) image.enabled = false;
		
	}
}
