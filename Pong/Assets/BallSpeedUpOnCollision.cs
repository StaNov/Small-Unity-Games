using UnityEngine;
using System.Collections;

public class BallSpeedUpOnCollision : MonoBehaviour {

    public float velocityMultiplierOnHit = 1.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionExit(Collision collision) {
        collision.gameObject.GetComponent<Rigidbody>().velocity *= velocityMultiplierOnHit;
    }
}
