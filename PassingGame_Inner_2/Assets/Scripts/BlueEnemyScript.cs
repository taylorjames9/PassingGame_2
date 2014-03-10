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
	public int targetChosen; 


	// Use this for initialization
	void Start () {
	
		//mainGuyScript = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
		mainGuy = GameObject.Find ("TheSelf");
		print (theTarget);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (StateManager.currentGameState == StateManager.GameState.redChaseState) {
			if (theTarget == null) {
				//targetChosen = 0;
				ChooseARedGuyToChase ();
			} else {
				print ("The chase is on!");
				ChaseTheTarget ();
			}
		}
	}

	public void ChooseARedGuyToChase (){
		int randNum = Random.Range (0, 1);


		if (targetChosen == 0) {
			if (randNum == 0) {
				//Choose Main Character
				theTarget = mainGuy.transform;
				print (theTarget);
				targetChosen++;


			} else if (randNum ==1){
				//Choose someone else from the RedTeamList
				//theTarget = 
				//targetChosen++;
				//Vector3 current = new Vector3 (transform.position.x, transform.position.y, 0);
				//Vector3 targetPos = new Vector3 (theTarget.position.x, theTarget.position.y, 0);
				//float step = speed * Time.deltaTime;
				//this.transform.position = Vector3.MoveTowards (current, targetPos, step);
				print ("Don't worry, you just didn't get the right random num");
			}

		}
	}


	public void ChaseTheTarget (){
		Vector3 current = new Vector3 (transform.position.x, transform.position.y, 0);
		Vector3 targetPos = new Vector3 (theTarget.position.x, theTarget.position.y, 0);
		float step = speed * Time.deltaTime;
		this.transform.position = Vector3.MoveTowards (current, targetPos, step);
	}














}
