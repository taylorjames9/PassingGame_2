using UnityEngine;
using System.Collections;

public class CharacterController_1 : MonoBehaviour {


	//static int speed = 5;
	//static int dampening = 10;
	public GameObject selfLayer1;
	public GameObject selfLayer2;
	public GameObject selfLayer3;




	void  Update () {


		if (Input.GetKey (KeyCode.UpArrow))
			rigidbody.AddForce (Vector3.up * 5);
		if (Input.GetKey (KeyCode.DownArrow))
			rigidbody.AddForce (Vector3.down * 5);
		if (Input.GetKey (KeyCode.LeftArrow))
			rigidbody.AddForce (Vector3.left * 5);
		if (Input.GetKey (KeyCode.RightArrow))
			rigidbody.AddForce (Vector3.right * 5);


		if (Input.GetKey (KeyCode.Space)) {
			ShowLayers ();
		}
	}
		



	void ShowLayers(){
		print ("show space running");

		//selfLayer1.transform.position.x = transform.position.x-1;
		//selfLayer2.transform.position.x = transform.position.x-2;

	}
}