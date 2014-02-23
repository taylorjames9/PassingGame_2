using UnityEngine;
using System.Collections;

public class UnderLayerScript : MonoBehaviour {

		public Transform target;
		public float smoothTime;
		public float zOffSet;
	//bool spaceDown = false;	
		public float followDistanceChooseNewLayer;
	//public float maxVelocity;

		private Vector3 velocity = Vector3.zero;
		public string gameObjectName;
		public GameObject CharContrllObject;
		CharacterController_1 CharContrllScript;

	void Start (){


		CharContrllScript = CharContrllObject.GetComponent<CharacterController_1>();

		gameObjectName = gameObject.transform.name;

		switch (gameObjectName) {
		case "selfLayer1":
			zOffSet = 0f;
			break;
		case "selfLayer2":
			zOffSet = 0.12f;
			break;
		case "selfLayer3":
			zOffSet = 0.24f;
			break;
		}



	}
		void Update() {

		if(!CharContrllScript.spaceDown){
			Vector3 targetPosition = new Vector3 (target.transform.position.x, target.transform.position.y, zOffSet);
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);
			}
		}
}
