using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioSource mainTrack;
	public AudioSource stingerTrack;
	public AudioClip victory;
	public AudioClip defeat;


	public void GameOver(){
		stingerTrack.clip = defeat;
		StartCoroutine ("FadeIn");
	}

	public void Victory(){
		stingerTrack.clip = victory;
		StartCoroutine ("FadeIn");
	}
	float fadeDuration = 1f;
	float mainTrackFade;
	float stingerTrackFade;
	float timer;
	IEnumerator FadeIn(){

		while (timer < fadeDuration) {
			timer += Time.deltaTime;
			mainTrack.volume -= Time.deltaTime;
			stingerTrack.volume += Time.deltaTime;
			yield return null;
		}


	}

}
