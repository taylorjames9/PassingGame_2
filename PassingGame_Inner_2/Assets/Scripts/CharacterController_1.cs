using UnityEngine;
using System.Collections;

public class CharacterController_1 : MonoBehaviour {


	//static int speed = 5;
	//static int dampening = 10;
	public GameObject selfLayer1;
	public GameObject selfLayer2;
	public GameObject selfLayer3;

	public float splayDistance;

	public GameObject invisibleLeader;


	void Start(){
		print (selfLayer1.transform.localPosition);
	}

	void  Update () {

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
		//print (selfLayer1.transform.localPosition);

		//selfLayer1.transform.position.y += splayDistance;

		selfLayer1.transform.position = new Vector3 (invisibleLeader.transform.position.x, (invisibleLeader.transform.position.y + splayDistance), (Random.Range(0,3)/10));
		selfLayer2.transform.position = new Vector3 ((invisibleLeader.transform.position.x - splayDistance), invisibleLeader.transform.position.y, (Random.Range(0,3)/10));
		selfLayer3.transform.position = new Vector3 (invisibleLeader.transform.position.x + splayDistance, invisibleLeader.transform.position.y, (Random.Range(0,3)/10));
	}
}