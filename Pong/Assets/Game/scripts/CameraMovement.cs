using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private Transform ball;

	void Start () {
	    ball = GameObject.FindGameObjectWithTag("Ball").transform;
	}
	
	void Update () {
		// TODO předělat nebo smazat
        Vector3 targetPosition = new Vector3(ball.position.x, transform.position.y, transform.position.z);
	    transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }
}
