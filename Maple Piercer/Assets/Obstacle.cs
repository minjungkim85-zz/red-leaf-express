using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float damageAmount =20;
	public bool isDestroyable = true;
	public GameObject[] pieces;
	public int pieceSpawnAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.35f, 1) * 20, ForceMode2D.Impulse);
	}

	void Destroy(){
		if(isDestroyable) StartCoroutine("DelayedDestroy");
		if (pieces.Length > 0) {
			int index = Random.Range(0, pieces.Length);
			GameObject p = pieces[index] ;
			for(int i = 0; i < pieceSpawnAmount; i++){
				GameObject o = Instantiate(p, transform.position + new Vector3(Random.Range(2,3),Random.Range(2,3),0), Quaternion.identity) as GameObject;
				o.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0,1),Random.Range(0,1)) * 10 ,ForceMode2D.Impulse);
			}
//			foreach(GameObject p in pieces){

//			}
		}
	}



	IEnumerator DelayedDestroy(){
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}
}
