using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	public GameManager gm;
	public Text text;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		float timeRemaining = gm.timer - gm.curTime;
		int min = (int)(timeRemaining / 60);
		int sec = (int)(timeRemaining % 60);
		if(sec < 10) text.text = min + ":0" + sec;
		else text.text = min + ":" + sec;
	}
}
