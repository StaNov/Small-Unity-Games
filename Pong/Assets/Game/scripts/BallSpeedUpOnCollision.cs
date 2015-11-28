using UnityEngine;
using System.Collections;

public class BallSpeedUpOnCollision : MonoBehaviour {

    public float velocityMultiplierOnHit = 1.1f;

	private static float SQRT_2 = Mathf.Sqrt(2);

    void OnCollisionExit(Collision collision) {
		FixDirection(collision);
    }

	void FixDirection(Collision collision) {
		Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
		float magnitude = rb.velocity.magnitude;

		rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x), Mathf.Sign(rb.velocity.y), 0f);
		rb.velocity *= magnitude / (SQRT_2);

		rb.velocity *= velocityMultiplierOnHit;
	}
}
