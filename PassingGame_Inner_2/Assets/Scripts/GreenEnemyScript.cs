using UnityEngine;
using System.Collections;

public class GreenEnemyScript : MonoBehaviour {




	//If the state is blueChaseState, then find a random blueGuy to chase. If theTarget becomes null. Choose a new target from blueguylist attached to aiInstantiatorScript.


	//If the state is redChaseState, then chase either MainRedCharacter or chooseRedTeamMate to chase. If theTarget becomes null, then choose
	//a new target from RedguyList;

	//If the state is greenChaseState, then choose a randomInvisible target to go to from invisible base list attached to InvisibleBaseSetterScript



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
