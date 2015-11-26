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
        float inputAxis = Input.GetAxis(playerSide.ToString());
        transform.Translate(Vector3.up * inputAxis * paddleSpeed * 0.01f);
    }
}
