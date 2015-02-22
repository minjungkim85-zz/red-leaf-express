using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] backgrounds;
	public float timer = 30f;
	public float curTime;
	public TrainEngine train;
	public PlayerController player;
//	public Transform trainTransform;
	public Transform stationTransform;
	public UIManager uiManager;
	public float travelPercentage = 0;
	float totalDist;
	float curDist;
	void Start(){
		if(Random.Range(0,2) >0) backgrounds[0].SetActive(true);
		else backgrounds[1].SetActive(true);
		totalDist = Vector3.Distance(train.transform.position, stationTransform.position);
	}
	bool isDead = false;
	public bool displayWarning = false;
	void Update(){
		curTime += Time.deltaTime;
		curDist = Vector3.Distance (train.transform.position, stationTransform.position);
//		Debug.Log (curDist / totalDist);
		travelPercentage = (1 - curDist / totalDist) ;
		if (travelPercentage > 0.8f && displayWarning == false) {
			displayWarning = true;
			train.BrakeWarning();
		}
		if (train.damage >= 100 && isDead == false) {
			isDead = true;
			train.rigidbody.drag = 4f;
			StartCoroutine("GameOver");
			train.rigidbody.AddForce(new Vector2(1,0.75f) * 1000, ForceMode2D.Impulse);
			train.rigidbody.AddTorque(-10, ForceMode2D.Impulse);
			player.enabled = false;
		}
	}

	IEnumerator GameOver(){
		yield return new WaitForSeconds (2f);
//		Time.timeScale = 0;
		uiManager.ShowGameOver();

//		Camera.main.GetComponent<CameraController>().enabled = false;
//		foreach(BGLooper bg in Camera.main.GetComponentsInChildren<BGLooper>()){
//			bg.enabled = false;
//		}
	}
	void Victory(){
		Debug.Log ("Victory!");
		uiManager.ShowVictory();
	}


	public void MainMenu(){
		Application.LoadLevel ("Start");
	}
	void OnGUI(){
//		GUILayout.Label ("Par time: " + timer);
//		GUILayout.Label ("Cur time: " + curTime);
//		GUILayout.Label ("Train speed: " + train.rigidbody.velocity.x);
//		if (train.damage < 100) {
//			GUILayout.Label ("Train damage: " + train.damage + " %");
//		} else {
//			GUILayout.Label ("Train damage: DESTROYED ");
//		}
//
//		GUILayout.Label ("Trip Completion: " + travelPercentage + " %");
	}


}
