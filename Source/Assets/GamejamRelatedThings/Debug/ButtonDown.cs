﻿using UnityEngine;
using System.Collections;

public class ButtonDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("A") != 0) {
			print ("A");
		}
	}
}
