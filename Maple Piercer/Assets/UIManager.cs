using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	public GameObject destroyedText;
	public GameObject hud;
	public GameObject failScreen;
	public GameObject winScreen;
	public void ShowGameOver(){
		failScreen.SetActive( true);
		hud.SetActive (false);
	}

	public void ShowVictory(){
		winScreen.SetActive( true);
		hud.SetActive (false);
	}
}
