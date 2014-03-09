using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class aiInstantiator : MonoBehaviour {

	public GameObject enemyGreenPrefab;
	public GameObject enemyBluePrefab;
	public GameObject aiTeamMatePrefab;

	public List<GameObject> greenManList = new List<GameObject>();
	public List<GameObject> blueManList = new List<GameObject>();
	public List<GameObject> teamMateList = new List<GameObject>();


	// Use this for initialization
	void Start () {

		for (int i = 0; i < 50; i++) {
			GameObject aNewGreyMan = Instantiate(enemyGreenPrefab, new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0), Quaternion.identity) as GameObject;
			greenManList.Add (aNewGreyMan);

			GameObject aNewWhiteMan = Instantiate(enemyBluePrefab, new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0), Quaternion.identity) as GameObject;
			blueManList.Add (aNewWhiteMan);

			GameObject aNewTeamMate = Instantiate(aiTeamMatePrefab, new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0), Quaternion.identity) as GameObject;
			teamMateList.Add (aNewTeamMate);

			i++;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
