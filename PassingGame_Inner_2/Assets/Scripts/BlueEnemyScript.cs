using UnityEngine;
using System.Collections;

public class BlueEnemyScript : MonoBehaviour {




	//If the state is greenChaseState, then find a random greenGuy to chase. If theTarget becomes null. Choose a new target from greenguylist attached to aiInstantiatorScript.


	//If the state is redChaseState, then chase either MainRedCharacter or chooseRedTeamMate to chase. If theTarget becomes null, then choose
	//a new target from RedguyList attached to aiInstantiator. 

	//If the state is blueChaseState, then choose a randomInvisible target to go to from invisible base list.

	Transform theTarget; 
	public float speed;
	GameObject mainGuy;
	public string targetChosen; 
	aiInstantiator aiSetterScript;


	// Use this for initialization
	void Start () {
	
		//mainGuyScript = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
		aiSetterScript = GameObject.Find("aiManager").GetComponent<aiInstantiator>();
		//greenManList

		mainGuy = GameObject.Find ("TheSelf");

		print (theTarget);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (StateManager.currentGameState == StateManager.GameState.redChaseState) {
			if (theTarget != null && targetChosen != "Red") {
				WipeTheSlate ();
				print ("wipetheSlate() just ran");
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
			if (theTarget != null && targetChosen != "Green") {
				WipeTheSlate ();
				print ("wipetheSlate() just ran");
			}

			if (theTarget == null) {
				ChooseAGreenGuyToChase ();
				print ("ChooseAGreenTarget just ran");
				//targetChosen++;
			} 
			if (theTarget != null && targetChosen == "Green") {
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

	public void ChooseAGreenGuyToChase (){
		GameObject theGreenManIChoose = aiSetterScript.greenManList [Random.Range (0, aiSetterScript.greenManList.Count)];
		Transform theGreenMansTransform = theGreenManIChoose.transform;
		theTarget = theGreenMansTransform;
		targetChosen = "Green";

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
}
