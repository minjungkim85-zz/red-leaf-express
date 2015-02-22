using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	public GameObject destroyedText;
	public GameObject hud;
	
	public void ShowGameOver(){
		destroyedText.SetActive( true);
		hud.SetActive (false);
	}
}
