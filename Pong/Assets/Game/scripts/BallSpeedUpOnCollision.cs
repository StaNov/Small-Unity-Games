using UnityEngine;
using System.Collections;

public class BallSpeedUpOnCollision : MonoBehaviour {

    public float velocityMultiplierOnHit = 1.1f;

    void OnCollisionExit(Collision collision) {
        collision.gameObject.GetComponent<Rigidbody>().velocity *= velocityMultiplierOnHit;
    }
}
