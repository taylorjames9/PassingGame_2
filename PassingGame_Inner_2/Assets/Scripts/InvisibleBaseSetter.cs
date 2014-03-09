using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InvisibleBaseSetter : MonoBehaviour {

	public GameObject invisibleBasePrefab;

	public List<GameObject> invisibleBaseList = new List<GameObject>();



	// Use this for initialization
	void Start () {

		for (int i = 0; i < 20; i++) {
			GameObject aNewInvisibleBase = Instantiate(invisibleBasePrefab, new Vector3(Random.Range(-50,50), Random.Range(-50,50), 0), Quaternion.identity) as GameObject;
			invisibleBaseList.Add (aNewInvisibleBase);

			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
