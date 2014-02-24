using UnityEngine;
using System.Collections;

public class DangerZone : MonoBehaviour {


	public Color color1 = Color.red;
	public Color color2 = Color.white;
	public float duration = 0.5F;



	/*void OnCollisionStay(Collision collisionInfo) {


		print (gameObject.name);
		StartCoroutine (ScreenBlinkRed ());


	}*/

	void OnTriggerStay(Collider other) {
		//Destroy(other.gameObject);
		StartCoroutine ("ScreenBlinkRed");
		//StopCoroutine ("ScreenBlinkRed");
	}

	void OnTriggerExit(Collider other){
		//Camera.main.backgroundColor = color2;


		StartCoroutine (StopScreenBlinkRed ());

	}


	IEnumerator ScreenBlinkRed(){
		yield return new WaitForSeconds (2.0f);
		/*Camera.main.backgroundColor = color1;
		yield return new WaitForSeconds (1.0f);
		Camera.main.backgroundColor = color2;
		yield return new WaitForSeconds (2.0f);*/

		float t = Mathf.PingPong(Time.time, duration) / duration;
		Camera.main.backgroundColor = Color.Lerp(color1, color2, t);
		yield return new WaitForSeconds (2.0f);
	}

	IEnumerator StopScreenBlinkRed(){
		//yield return new WaitForSeconds (1.0f);

		StopCoroutine ("ScreenBlinkRed");
		yield return new WaitForSeconds (0.5f);

		Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, color2, 3.0f);

		//Camera.main.backgroundColor = color2;

	}
}
