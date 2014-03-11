using UnityEngine;
using System.Collections;

public class ReplayBtnScript : MonoBehaviour {



	public void OnMouseUp(){
		Application.LoadLevel("PassingGame_Scene1");


		if(Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel("PassingGame_Scene1");

		}

	}

}
