﻿using UnityEngine;
using System.Collections;

public class TargetTracker : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position;
	}
}
