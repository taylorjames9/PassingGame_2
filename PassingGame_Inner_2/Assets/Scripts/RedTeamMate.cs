using UnityEngine;
using System.Collections;

public class RedTeamMate : MonoBehaviour {



	//if the state is greenchasestate then ChooseANewGreenGuyToChase from the greenguylist attached to the aiInstantiator. 
	//If theTarget is null, ChooseANewGreenGuyToChase from the greenguylist attached to the aiInstantiator. 

	//if the state is blueChaseState then ChooseANewBlueGuyToChase from the blueguylist attached to the AiInstanstiator.
	//If theTarget is null, ChooseANewBlueGuyToChase from the blueguylist attached to the aiInstantiator. 

	//if the state is redChaseState then choose a base from the baseList attached to the InvisibleBaseSetterOBJ. 

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

		if (StateManager.currentGameState == StateManager.GameState.greenChaseState) {

			if (theTarget != null && targetChosen != "Green") {
				WipeTheSlate ();
			}
			if (theTarget == null) {
				ChooseAGreenGuyToChase ();
			} 
			if (theTarget != null && targetChosen == "Green") {
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

	public void ChooseAGreenGuyToChase (){
		if (aiSetterScript.greenManList.Count > 0) {
			GameObject theGreenManIChoose = aiSetterScript.greenManList [Random.Range (0, aiSetterScript.greenManList.Count)];
			Transform theGreenMansTransform = theGreenManIChoose.transform;
			theTarget = theGreenMansTransform;
			targetChosen = "Green";
		} else if (aiSetterScript.blueManList.Count == 0) {
			GameObject theBaseIChoose = invisibleBaseScript.invisibleBaseList [Random.Range (0, invisibleBaseScript.invisibleBaseList.Count)];
			Transform theBaseTransform = theBaseIChoose.transform;
			theTarget = theBaseTransform;
			targetChosen = "Base";
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
		if (StateManager.currentGameState == StateManager.GameState.redChaseState ) {
			if (otherCol.gameObject.tag == "green" || otherCol.gameObject.tag == "blue") { 
				if (!iAmSafe) {
					aiSetterScript.teamMateList.Remove (gameObject);
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
