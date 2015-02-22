using UnityEngine;
using System.Collections;

public class TextGenerator : MonoBehaviour {

	string[] textAll = {
		"There are 1459 cheeses in the Canadian cheese directory!",
		"Quebec produces 64% of cheese types in Canada!",
		"30% of Canadian-made cheeses are described as being mild!",
		"On average, Canadian cheeses have a fat content of 26%!",
		"Cheese manufacturers can be described as artisanal, farmstead, or industrial!"
	};
	
	int textID;
	string currText;

	
	// Use this for initialization
	void Start () {
		textID = Random.Range (0,textAll.GetLength(0));
		currText = textAll[textID];
		Debug.Log (currText);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
