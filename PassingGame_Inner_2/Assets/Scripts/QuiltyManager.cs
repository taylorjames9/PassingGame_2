using UnityEngine;
using System.Collections;

public class QuiltyManager : MonoBehaviour {


	
	public GameObject quiltSquareGrey;


	// Use this for initialization
	void Start () {

		APatchWorkQuilty ();


	}

	public void APatchWorkQuilty (){
		for (int i = 0; i < 800; i++) {

			Instantiate(quiltSquareGrey, new Vector3(Random.Range(-50,50), Random.Range(-50,50), 1), Quaternion.identity);

		}
	}
}
