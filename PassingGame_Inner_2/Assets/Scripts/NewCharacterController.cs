﻿using UnityEngine;
using System.Collections;

public class NewCharacterController : MonoBehaviour {


	public int spaceDownCounter;
	public	GameObject trueColorOBJ;
	TrueColor trueColorScript;
	public string myVisibleColor;
	private int stopGateForSpaceDown;


	// Use this for initialization
	void Start () {
		myVisibleColor = "Red";
		trueColorScript = trueColorOBJ.GetComponent<TrueColor>();

	}
	
	void  FixedUpdate () {

		IncreaseTrueColorAsAResultOfPassingColor ();

	
		if (Input.GetKey (KeyCode.UpArrow))
			rigidbody.AddForce (Vector3.up * 5);
		if (Input.GetKey (KeyCode.DownArrow))
			rigidbody.AddForce (Vector3.down * 5);
		if (Input.GetKey (KeyCode.LeftArrow))
			rigidbody.AddForce (Vector3.left * 5);
		if (Input.GetKey (KeyCode.RightArrow))
			rigidbody.AddForce (Vector3.right * 5);

		if (Input.GetKeyDown (KeyCode.Space) && stopGateForSpaceDown ==0 ) {
			stopGateForSpaceDown++;
			spaceDownCounter++; 
			switch (spaceDownCounter % 3) {
			case 0:
				transform.renderer.material.color = Color.red;
				myVisibleColor = "Red";
				print ("myVisibleColor" + myVisibleColor);

				break;
			case 1:
				transform.renderer.material.color = Color.green;
				myVisibleColor = "Green";
				print("myVisibleColor" + myVisibleColor);
				break;
			case 2:
				transform.renderer.material.color = Color.blue;
				myVisibleColor = "Blue";
				print("myVisibleColor" + myVisibleColor);
				break;
			default: 

				break;
			
			}
		}
		else if (Input.GetKeyUp (KeyCode.Space)) {
			stopGateForSpaceDown = 0;
		}
	}

	public void IncreaseTrueColorAsAResultOfPassingColor (){
		switch (myVisibleColor) {
		case "Red":
			trueColorScript.AmountRedIncrease ();
			trueColorScript.AmountGreenDecrease ();
			trueColorScript.AmountBlueDecrease ();
			break;
		case "Green":
			trueColorScript.AmountRedDecrease ();
			trueColorScript.AmountGreenIncrease ();
			trueColorScript.AmountBlueDecrease ();
			break;
		case "Blue":
			trueColorScript.AmountRedDecrease ();
			trueColorScript.AmountGreenDecrease ();
			trueColorScript.AmountBlueIncrease ();
			break;
		default:

			break;
		}
	}



















}