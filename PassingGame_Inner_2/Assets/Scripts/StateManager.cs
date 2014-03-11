using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {


	public enum GameState {redChaseState, greenChaseState, blueChaseState, endOfGame}

	public static GameState currentGameState;

	//public GameObject ResourceManagerOBJ;

	public GameObject topViewRed;
	public GameObject topViewGreen;
	public GameObject topViewBlue;

	public TextMesh redTeamNumLeft;
	public TextMesh greenTeamNumLeft;
	public TextMesh blueTeamNumLeft;

	aiInstantiator aiSetterScript;


	// Use this for initialization
	void Start () {

		topViewRed.SetActive (true);
		topViewGreen.SetActive (false);
		topViewBlue.SetActive (false);
		currentGameState = GameState.redChaseState; 

		aiSetterScript = GameObject.Find("aiManager").GetComponent<aiInstantiator>();
	}

	// Update is called once per frame
	void Update () {

		print (currentGameState); 
		//timer.text = Time.time.ToString();

		redTeamNumLeft.text = ("R " + aiSetterScript.teamMateList.Count.ToString());
		greenTeamNumLeft.text = ("G " + aiSetterScript.greenManList.Count.ToString());
		blueTeamNumLeft.text = ("B " + aiSetterScript.blueManList.Count.ToString());



		if(aiSetterScript.greenManList.Count == 0 &&  aiSetterScript.blueManList.Count == 0){
			redTeamNumLeft.text = "Red Wins";

		}


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
