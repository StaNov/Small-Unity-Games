using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour {

    public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
        SpawnBall();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnBall() {
        GameObject ball = GameObject.Instantiate(ballPrefab);
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(5, 5, 0), ForceMode.Impulse);
    }
}
