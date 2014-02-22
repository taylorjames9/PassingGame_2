using UnityEngine;
using System.Collections;

public class UnderLayerScript : MonoBehaviour {

		public Transform target;
		public float smoothTime;
		public float zOffSet;
		bool spaceDown = false;	
		public float followDistanceChooseNewLayer;
	//public float maxVelocity;

		private Vector3 velocity = Vector3.zero;

	void Start (){


	}


		void Update() {


			Vector3 targetPosition = new Vector3 (target.transform.position.x, target.transform.position.y, zOffSet);
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);

		/*if (Input.GetKey (KeyCode.Space)) {
			spaceDown = !spaceDown;
		}
			
		if (spaceDown) {
			smoothTime += followDistanceChooseNewLayer;
			print ("SpaceDown set to true");

		} else if (!spaceDown) {
			print ("Not space down");
			smoothTime -= followDistanceChooseNewLayer;
		}*/

	}
}
