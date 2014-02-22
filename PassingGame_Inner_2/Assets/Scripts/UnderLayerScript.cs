using UnityEngine;
using System.Collections;

public class UnderLayerScript : MonoBehaviour {

		public Transform target;
		public float smoothTime;
	public float zOffSet;
		private Vector3 velocity = Vector3.zero;
		void Update() {
		Vector3 targetPosition = new Vector3 (target.transform.position.x, target.transform.position.y, zOffSet);


			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}
}
