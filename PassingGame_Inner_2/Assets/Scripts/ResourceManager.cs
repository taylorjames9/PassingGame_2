using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	public GameObject switcherPrefab; 
	public static int numResources;
	//public TextMesh timer;


	void Start () {

		for (int i = 0; i < 20; i++) {
			Instantiate(switcherPrefab, new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0), Quaternion.identity);
			numResources++;
			//print (numResources);

		}
	}

	void Update () {
		if(numResources < 20) {
			Instantiate(switcherPrefab, new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0), Quaternion.identity);
			numResources++;
		}

	}
}
