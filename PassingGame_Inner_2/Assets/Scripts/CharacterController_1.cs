using UnityEngine;
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

		selfLayerScript1.zOffSet = selfLayerScript2.zOffSet;
		selfLayerScript2.zOffSet = selfLayerScript3.zOffSet;
		selfLayerScript3.zOffSet = selfLayerScript1.zOffSet;

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

























