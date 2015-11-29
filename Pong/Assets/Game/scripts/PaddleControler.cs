using UnityEngine;
using System.Collections;

public enum PlayerSide {
    Left, Right, Unassigned
}

public class PaddleControler : MonoBehaviour {

    public PlayerSide playerSide = PlayerSide.Unassigned;
    public float paddleSpeed = 5;
	public bool enablePlayerControl = true;

	private static float MAX_Y_POS = 11.9f;

    void FixedUpdate() {
		if (!enablePlayerControl) {
			return;
		}

        float inputAxis = Input.GetAxisRaw(playerSide.ToString());

		if (inputAxis > 0) {
			MoveUp();
		} else if (inputAxis < 0) {
			MoveDown();
		}
	}
	
	public void MoveUp() {
		Move(Vector3.up);
		if (transform.position.y > MAX_Y_POS) {
			transform.position = new Vector3(transform.position.x, MAX_Y_POS, transform.position.z);
		}
	}
	
	public void MoveDown() {
		Move(Vector3.down);
		if (transform.position.y < -MAX_Y_POS) {
			transform.position = new Vector3(transform.position.x, -MAX_Y_POS, transform.position.z);
		}
	}
	
	private void Move(Vector3 direction) {
		transform.Translate(direction * paddleSpeed * Time.deltaTime);
	}
}
