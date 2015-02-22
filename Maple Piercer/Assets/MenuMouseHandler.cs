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
		
		float waitDurS  = .2f;
		Invoke ("callScreen", waitDurS);
	
	}
	
	public void callScreen(){
		if (this.name == "Play"){
			Application.LoadLevel("main");
		}else if (this.name == "EndStr"){
			Application.LoadLevel ("start");
		}
	}
}
