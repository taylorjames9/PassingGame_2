using UnityEngine;
using System.Collections;

public class Talk : MonoBehaviour {



	public GameObject mySpeechBubble;

	public GameObject[] possibleSpeechBubbles;


	// Use this for initialization
	void Start () {

		if (gameObject.name == "Dark_Blue_BackDrop") {
			mySpeechBubble = possibleSpeechBubbles [0];
		}
		else if(gameObject.name == "LightBlue_Backdrop"){
			mySpeechBubble = possibleSpeechBubbles [1];

		}
		else if(gameObject.name == "Red_Chit"){
			mySpeechBubble = possibleSpeechBubbles [2];

		}

		mySpeechBubble.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider otherCollider){

		print ("you hit ME");
		mySpeechBubble.SetActive (true);
	}

	void OnTriggerExit(Collider otherCollider){

		print ("you hit ME");
		mySpeechBubble.SetActive (false);
	}

}
