using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public float timer = 10f;
	float curTime;
	public TrainEngine train;
//	public Transform trainTransform;
	public Transform stationTransform;
	float travelPercentage = 0;
	float totalDist;
	float curDist;
	void Start(){
		totalDist = Vector3.Distance(train.transform.position, stationTransform.position);
	}

	void Update(){
		curTime += Time.deltaTime;
		curDist = Vector3.Distance (train.transform.position, stationTransform.position);
//		Debug.Log (curDist / totalDist);
		travelPercentage = (1 - curDist / totalDist) * 100;
	}

	void OnGUI(){
		GUILayout.Label ("Par time: " + timer);
		GUILayout.Label ("Cur time: " + curTime);
		GUILayout.Label ("Train speed: " + train.rigidbody.velocity.x);
		GUILayout.Label ("Trip Completion %: " + travelPercentage);
	}

}
