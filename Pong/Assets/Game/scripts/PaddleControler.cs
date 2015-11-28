using UnityEngine;
using System.Collections;

public enum PlayerSide {
    Left, Right, Unassigned
}

public class PaddleControler : MonoBehaviour {

    public PlayerSide playerSide = PlayerSide.Unassigned;
    public float paddleSpeed = 5;

    void FixedUpdate() {
        // TODO předělat na fyziku
        float inputAxis = Input.GetAxisRaw(playerSide.ToString());

		if (inputAxis > 0) {
			MoveUp();
		} else if (inputAxis < 0) {
			MoveDown();
		}
	}
	
	public void MoveUp() {
		Move(Vector3.up);
	}
	
	public void MoveDown() {
		Move(Vector3.down);
	}
	
	private void Move(Vector3 direction) {
		transform.Translate(direction * paddleSpeed * Time.deltaTime);
	}
}
