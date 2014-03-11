using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {


	public enum GameState {redChaseState, greenChaseState, blueChaseState, endOfGame}

	public static GameState currentGameState;

	//public GameObject ResourceManagerOBJ;

	public GameObject topViewRed;
	public GameObject topViewGreen;
	public GameObject topViewBlue;

	// Use this for initialization
	void Start () {

		topViewRed.SetActive (true);
		topViewGreen.SetActive (false);
		topViewBlue.SetActive (false);
		currentGameState = GameState.redChaseState; 
	}

	// Update is called once per frame
	void Update () {

		print (currentGameState); 
		//timer.text = Time.time.ToString();


		switch(currentGameState){
		case GameState.redChaseState:
			topViewRed.SetActive (true);
			topViewGreen.SetActive (false);
			topViewBlue.SetActive (false);
			break;
		case GameState.greenChaseState:
			topViewRed.SetActive (false);
			topViewGreen.SetActive (true);
			topViewBlue.SetActive (false);
			break;
		case GameState.blueChaseState:
			topViewRed.SetActive (false);
			topViewGreen.SetActive (false);
			topViewBlue.SetActive (true);
			break;
		case GameState.endOfGame:

			break;
		default:
			print("no target sample to display");
			break;
		}
	}

	public void RandomResourceTargetChooser (){

	}


	public static GameState RandomChaseStateChooser (){
		int randomNum = Random.Range (0, 3);
		switch(randomNum){
		case 0:
			currentGameState = GameState.redChaseState;
			break;
		case 1:
			currentGameState = GameState.greenChaseState;
			break;
		case 2:
			currentGameState = GameState.blueChaseState;
			break;
		default:
			print ("No State");
			break;
		}
		return currentGameState;
	}


}
