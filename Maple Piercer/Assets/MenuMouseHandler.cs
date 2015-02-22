using UnityEngine;
using System.Collections;

public class MenuMouseHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnMouseDown(){
		if (this.name == "Play"){
			Application.LoadLevel("main");
		}
	}
}
