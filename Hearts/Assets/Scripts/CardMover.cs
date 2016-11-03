using UnityEngine;
using System.Collections;

public class CardMover : MonoBehaviour {

	// TODO advanced tweened animations
	
	void Update () {
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
}
