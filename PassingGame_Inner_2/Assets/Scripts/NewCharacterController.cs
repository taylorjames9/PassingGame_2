using UnityEngine;
using System.Collections;

public class NewCharacterController : MonoBehaviour {


	public int spaceDownCounter;
	public	GameObject trueColorOBJ;
	TrueColor trueColorScript;
	public string myVisibleColor;
	private int stopGateForSpaceDown;
	public bool iAmSafe;
	public	TextMesh gameOverText;
	public GameObject gameOverBlackOBJ;


	// Use this for initialization
	void Start () {
		myVisibleColor = "Red";
		trueColorScript = trueColorOBJ.GetComponent<TrueColor>();

		//gameOverText.renderer.enabled = false;
		//gameOverBlackOBJ.SetActive (false);

	}
	
	void  FixedUpdate () {

		IncreaseTrueColorAsAResultOfPassingColor ();

	
		if (Input.GetKey (KeyCode.UpArrow))
			rigidbody.AddForce (Vector3.up * 45);
		if (Input.GetKey (KeyCode.DownArrow))
			rigidbody.AddForce (Vector3.down * 45);
		if (Input.GetKey (KeyCode.LeftArrow))
			rigidbody.AddForce (Vector3.left * 45);
		if (Input.GetKey (KeyCode.RightArrow))
			rigidbody.AddForce (Vector3.right * 45);

		if (Input.GetKeyDown (KeyCode.Space) && stopGateForSpaceDown ==0 ) {
			stopGateForSpaceDown++;
			spaceDownCounter++; 
			switch (spaceDownCounter % 3) {
			case 0:
				transform.renderer.material.color = Color.red;
				myVisibleColor = "Red";
				print ("myVisibleColor" + myVisibleColor);
				gameObject.tag = "redMain";
				print ("my tag is now: " + gameObject.tag);

				break;
			case 1:
				transform.renderer.material.color = Color.green;
				myVisibleColor = "Green";
				print("myVisibleColor" + myVisibleColor);
				gameObject.tag = "greenMain";
				print ("my tag is now: " + gameObject.tag);
				break;
			case 2:
				transform.renderer.material.color = Color.blue;
				myVisibleColor = "Blue";
				print("myVisibleColor" + myVisibleColor);
				gameObject.tag = "blueMain";
				print ("my tag is now: " + gameObject.tag);
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

	/*public void OnCollisionEnter(Collision otherCol){
		if (StateManager.currentGameState == StateManager.GameState.redChaseState ) {
			if (otherCol.gameObject.tag == "blue" || otherCol.gameObject.tag == "green") { 
				if (!iAmSafe) {
					//gameOverText.SetActive (true);
					//gameOverText.renderer.SetActive (false);
					//gameOverText.renderer.enabled = true;
					//gameOverText.transform.position.z = 0.5f;
					//gameOverBlackOBJ.SetActive (true);
					//gameObject.SetActive (false);

					Application.LoadLevel("GameOverScreen");


				}
			}
		}
	}*/
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
