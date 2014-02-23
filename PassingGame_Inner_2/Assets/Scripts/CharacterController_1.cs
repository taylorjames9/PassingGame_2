﻿using UnityEngine;
using System.Collections;

public class CharacterController_1 : MonoBehaviour {


	//static int speed = 5;
	//static int dampening = 10;
	public GameObject selfLayer1;
	public GameObject selfLayer2;
	public GameObject selfLayer3;

	UnderLayerScript selfLayerScript1;
	UnderLayerScript selfLayerScript2;
	UnderLayerScript selfLayerScript3;

	public float layerOrder;

	public float forceSplay;

	public GameObject invisibleLeader;


	void Start(){
		print (selfLayer1.transform.localPosition);
		forceSplay = 0.000005f;

		selfLayerScript1 = selfLayer1.GetComponent<UnderLayerScript>();
		selfLayerScript2 = selfLayer2.GetComponent<UnderLayerScript>();
		selfLayerScript3 = selfLayer3.GetComponent<UnderLayerScript>();




	}

	void  FixedUpdate () {

		print (selfLayer1.transform.localPosition);

		if (Input.GetKey (KeyCode.UpArrow))
			rigidbody.AddForce (Vector3.up * 5);
		if (Input.GetKey (KeyCode.DownArrow))
			rigidbody.AddForce (Vector3.down * 5);
		if (Input.GetKey (KeyCode.LeftArrow))
			rigidbody.AddForce (Vector3.left * 5);
		if (Input.GetKey (KeyCode.RightArrow))
			rigidbody.AddForce (Vector3.right * 5);


		if (Input.GetKeyUp (KeyCode.Space)) {
			SplayShuffle ();
		} 
	}

	void SplayShuffle(){

		selfLayer1.rigidbody.velocity = new Vector3 (0, 10, 0);
		selfLayer2.rigidbody.velocity = new Vector3 (10, 0, 0);
		selfLayer3.rigidbody.velocity = new Vector3 (-10, 0, 0);

		/*selfLayer1.transform.position = new Vector3 (selfLayer1.transform.position.x, selfLayer1.transform.position.y,selfLayer2.transform.position.z);
		selfLayer2.transform.position = new Vector3 (selfLayer2.transform.position.x, selfLayer2.transform.position.y,selfLayer3.transform.position.z);
		selfLayer3.transform.position = new Vector3 (selfLayer3.transform.position.x, selfLayer3.transform.position.y,selfLayer1.transform.position.z);*/

		StartCoroutine (StopVelocity ());

	}

	IEnumerator StopVelocity(){

		float zOffSetBeforeShift_1 = selfLayerScript1.zOffSet;
		float zOffSetBeforeShift_2 = selfLayerScript2.zOffSet;
		float zOffSetBeforeShift_3 = selfLayerScript3.zOffSet;

		selfLayerScript1.zOffSet = zOffSetBeforeShift_2;
		selfLayerScript2.zOffSet = zOffSetBeforeShift_3;
		selfLayerScript3.zOffSet = zOffSetBeforeShift_1;

		float smoothTimeBeforeShift_1 = selfLayerScript1.smoothTime;
		float smoothTimeBeforeShift_2 = selfLayerScript2.smoothTime;
		float smoothTimeBeforeShift_3 = selfLayerScript3.smoothTime;

		selfLayerScript1.smoothTime = smoothTimeBeforeShift_2; 
		selfLayerScript2.smoothTime = smoothTimeBeforeShift_3; 
		selfLayerScript3.smoothTime = smoothTimeBeforeShift_1; 

		float followDistanceChooseNewLayer_BeforeShift_1 = selfLayerScript1.followDistanceChooseNewLayer;
		float followDistanceChooseNewLayer_BeforeShift_2 = selfLayerScript2.followDistanceChooseNewLayer;
		float followDistanceChooseNewLayer_BeforeShift_3 = selfLayerScript3.followDistanceChooseNewLayer;

		selfLayerScript1.followDistanceChooseNewLayer = followDistanceChooseNewLayer_BeforeShift_2;
		selfLayerScript2.followDistanceChooseNewLayer = followDistanceChooseNewLayer_BeforeShift_3;
		selfLayerScript3.followDistanceChooseNewLayer = followDistanceChooseNewLayer_BeforeShift_1;

		yield return new WaitForSeconds(0.1f);
		selfLayer1.rigidbody.velocity = new Vector3 (0, 0, 0);
		selfLayer2.rigidbody.velocity = new Vector3 (0, 0, 0);
		selfLayer3.rigidbody.velocity = new Vector3 (0, 0, 0);

	}

	public float NewTopSelf(){
			return (Random.Range (0, 3) / 10);
	}
}

























