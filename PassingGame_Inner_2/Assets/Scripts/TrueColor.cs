using UnityEngine;
using System.Collections;

public class TrueColor : MonoBehaviour {


	public float amountRed;
	public float amountGreen;
	public float amountBlue;


	// Use this for initialization
	void Start () {
		amountRed = 1;



	}
	
	// Update is called once per frame
	void Update () {
	
		transform.renderer.material.color = new Color (amountRed, amountGreen, amountBlue, 1);

	}



	public void AmountRedIncrease (){
		if (amountRed < 1) {
			amountRed = amountRed + (Time.deltaTime/35); 
			//print (amountRed);
		}

	}

	public void AmountGreenIncrease (){
		if (amountGreen < 1) {
			amountGreen = amountGreen + (Time.deltaTime/35); 
			//print (amountGreen);
		}

	}

	public void AmountBlueIncrease (){
		if (amountBlue < 1) {
			amountBlue = amountBlue + (Time.deltaTime/35); 
			//print (amountBlue);
		}

	}

	public void AmountRedDecrease (){
		if (amountRed > 0) {
			amountRed = amountRed - (Time.deltaTime/35); 
			//print (amountRed);
		}
	}

	public void AmountGreenDecrease (){
		if (amountGreen > 0) {
			amountGreen = amountGreen - (Time.deltaTime/35); 
			//print (amountGreen);
		}

	}

	public void AmountBlueDecrease (){
		if (amountBlue > 0) {
			amountBlue = amountBlue - (Time.deltaTime/35); 
			//print (amountBlue);
		}

	}
}
