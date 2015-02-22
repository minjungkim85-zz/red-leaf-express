using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour {

	public TrainEngine e;
	Text t;
	
	float collideTime, currTime;
	float displayDurS = 2;
	
	string[] textAll = {
		"",
		"There are 1459 cheeses in the Canadian cheese directory!",
		"Quebec produces 64% of cheese types in Canada!",
		"30% of Canadian-made cheeses are described as being mild!",
		"On average, Canadian cheeses have a fat content of 26%!",
		"Cheese manufacturers can be described as artisanal, farmstead, or industrial!"
	};
	
	public int textID;
	
	// Use this for initialization
	void Start () {
		t = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (e.collided){
			textID = Random.Range (1,textAll.GetLength(0));
			collideTime = Time.time;
			e.collided = false;
		}
		
		currTime = Time.time;
		
		if( (currTime - collideTime) > displayDurS){
			textID = 0;
		}
		
		t.text = textAll[textID];	
		
		
	}
}
