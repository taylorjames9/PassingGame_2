using UnityEngine;
using System.Collections;

public class CharacterController_1 : MonoBehaviour {


	//static int speed = 5;
	//static int dampening = 10;
	public GameObject selfLayer1;
	public GameObject selfLayer2;
	public GameObject selfLayer3;

	public float layerOrder;

	public float forceSplay;

	public GameObject invisibleLeader;


	void Start(){
		print (selfLayer1.transform.localPosition);
		forceSplay = 0.000005f;
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


		if (Input.GetKey (KeyCode.Space)) {
			SplayShuffle ();
		} 
	}

	void SplayShuffle(){

		selfLayer1.rigidbody.velocity = new Vector3 (0, 10, 0);
		selfLayer2.rigidbody.velocity = new Vector3 (10, 0, 0);
		selfLayer3.rigidbody.velocity = new Vector3 (-10, 0, 0);

		StartCoroutine (StopVelocity ());

	}

	IEnumerator StopVelocity(){
		yield return new WaitForSeconds(0.1f);
		selfLayer1.rigidbody.velocity = new Vector3 (0, 0, 0);
		selfLayer2.rigidbody.velocity = new Vector3 (0, 0, 0);
		selfLayer3.rigidbody.velocity = new Vector3 (0, 0, 0);

	}

	public float NewTopSelf(){
			return (Random.Range (0, 3) / 10);
	}
}

























