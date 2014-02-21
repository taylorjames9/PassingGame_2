using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {


	static int speed = 5;
	//static int dampening = 10;

	void  Update () {


		if (Input.GetKey (KeyCode.UpArrow)) rigidbody.AddForce(Vector3.up * 3);
		if (Input.GetKey (KeyCode.DownArrow)) rigidbody.AddForce(Vector3.down * 3);
		if (Input.GetKey (KeyCode.LeftArrow)) rigidbody.AddForce(Vector3.left * 3);
		if (Input.GetKey (KeyCode.RightArrow)) rigidbody.AddForce(Vector3.right * 3);


		if (Input.GetKey (KeyCode.Space))
			ShowLayers ();
	}

	void ShowLayers(){
		print ("show space running");
	}
}