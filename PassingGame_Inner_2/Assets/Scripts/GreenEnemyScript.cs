﻿using UnityEngine;
using System.Collections;

public class GreenEnemyScript : MonoBehaviour {




	//If the state is blueChaseState, then find a random blueGuy to chase. If theTarget becomes null. Choose a new target from blueguylist attached to aiInstantiatorScript.


	//If the state is redChaseState, then chase either MainRedCharacter or chooseRedTeamMate to chase. If theTarget becomes null, then choose
	//a new target from RedguyList;

	//If the state is greenChaseState, then choose a randomInvisible target to go to from invisible base list attached to InvisibleBaseSetterScript


	Transform theTarget; 
	public float speed;
	GameObject mainGuy;
	public string targetChosen; 
	aiInstantiator aiSetterScript;
	InvisibleBaseSetter invisibleBaseScript;
	public bool iAmSafe;


	// Use this for initialization
	void Start () {

		aiSetterScript = GameObject.Find("aiManager").GetComponent<aiInstantiator>();
		invisibleBaseScript = GameObject.Find("InvisibleBaseManager").GetComponent<InvisibleBaseSetter>();
		mainGuy = GameObject.Find ("TheSelf");

	
	}
	void FixedUpdate () {

		if (StateManager.currentGameState == StateManager.GameState.redChaseState) {
			if (theTarget != null && targetChosen != "Red") {
				WipeTheSlate ();
			}

			if (theTarget == null) {
				ChooseARedGuyToChase ();
			} 
			if (theTarget != null && targetChosen == "Red") {
				if (theTarget.gameObject.tag == "redMain" || theTarget.gameObject.tag == "redTeamMate") {
					ChaseTheTarget ();
				}
			}
		}

		if (StateManager.currentGameState == StateManager.GameState.greenChaseState) {

			if (theTarget != null && targetChosen != "Base") {
				WipeTheSlate ();
			}

			if (theTarget == null) {
				ChooseAnInvisibleBase ();
			} 
			if (theTarget != null && targetChosen == "Base") {
				ChaseTheTarget();
			}
		}

		if (StateManager.currentGameState == StateManager.GameState.blueChaseState) {
			if (theTarget != null && targetChosen != "Blue") {
				WipeTheSlate ();
			}
			if (theTarget == null) {
				ChooseABlueGuyToChase ();
			} 
			if (theTarget != null && targetChosen == "Blue") {
				ChaseTheTarget();
			}

		}
	}

	public void ChooseARedGuyToChase (){
		int randNum = Random.Range (0, 2);

		if (randNum == 0) {
			//Choose Main Character
			theTarget = mainGuy.transform;
			print (theTarget);
			targetChosen = "Red";


		} else if (randNum ==1){
			//Choose someone else from the RedTeamList
			GameObject theRedManIChoose = aiSetterScript.teamMateList [Random.Range (0, aiSetterScript.teamMateList.Count)];
			Transform theRedMansTransform = theRedManIChoose.transform;
			theTarget = theRedMansTransform;
			targetChosen = "Red";
		}
	}

	public void ChooseABlueGuyToChase (){
		if (aiSetterScript.blueManList.Count > 0) {
			GameObject theBlueManIChoose = aiSetterScript.blueManList [Random.Range (0, aiSetterScript.blueManList.Count)];
			Transform theBlueMansTransform = theBlueManIChoose.transform;
			theTarget = theBlueMansTransform;
			targetChosen = "Blue";
		} else if (aiSetterScript.blueManList.Count == 0) {
			GameObject theBaseIChoose = invisibleBaseScript.invisibleBaseList [Random.Range (0, invisibleBaseScript.invisibleBaseList.Count)];
			Transform theBaseTransform = theBaseIChoose.transform;
			theTarget = theBaseTransform;
			targetChosen = "Base";
		}

	}

	public void ChooseAnInvisibleBase (){
		GameObject theBaseIChoose = invisibleBaseScript.invisibleBaseList [Random.Range (0, invisibleBaseScript.invisibleBaseList.Count)];
		Transform theBaseTransform = theBaseIChoose.transform;
		theTarget = theBaseTransform;
		targetChosen = "Base";
	}


	public void ChaseTheTarget (){
		Vector3 current = new Vector3 (transform.position.x, transform.position.y, 0);
		Vector3 targetPos = new Vector3 (theTarget.position.x, theTarget.position.y, 0);
		float step = speed * Time.deltaTime;
		this.transform.position = Vector3.MoveTowards (current, targetPos, step);
	}

	public void WipeTheSlate(){
		theTarget = null;
		//targetChosen = false;
	}

	public void OnCollisionEnter(Collision otherCol){
		if (StateManager.currentGameState == StateManager.GameState.greenChaseState ) {
			if (!iAmSafe) {
				if (otherCol.gameObject.tag == "redMain" || otherCol.gameObject.tag == "greenMain" || otherCol.gameObject.tag == "blueMain" || otherCol.gameObject.tag == "blue" || otherCol.gameObject.tag == "redTeamMate") { 
					aiSetterScript.greenManList.Remove (gameObject);
					Destroy (gameObject);
				}
			}
		}
	}
	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == "base"){
			iAmSafe = true;
		}

	}
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "base"){
			iAmSafe = false;
		}
	}

}
