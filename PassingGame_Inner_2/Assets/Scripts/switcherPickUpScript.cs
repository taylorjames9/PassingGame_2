﻿using UnityEngine;
using System.Collections;

public class switcherPickUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "main") {

		StateManager.currentGameState = StateManager.RandomChaseStateChooser ();
		Destroy (gameObject);
		ResourceManager.numResources--;
		print (ResourceManager.numResources);
		}
	}
}
