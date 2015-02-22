using UnityEngine;
using System.Collections;

public class TravelMarker : MonoBehaviour {
	public float startX;
	public float endX;
	public GameManager g;
	RectTransform rect;
	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Lerp(startX, endX, g.travelPercentage);
		rect.anchoredPosition = new Vector2 (x, rect.anchoredPosition.y);
	}
}
