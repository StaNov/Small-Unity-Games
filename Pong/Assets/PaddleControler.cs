using UnityEngine;
using System.Collections;

public class PaddleControler : MonoBehaviour {

    public PaddleType paddleType = PaddleType.Unassigned;
    public float paddleSpeed = 5;

    public enum PaddleType {
        Left, Right, Unassigned
    }

    void FixedUpdate() {
        float inputAxis = Input.GetAxis(paddleType.ToString());
        transform.Translate(Vector3.up * inputAxis * paddleSpeed * 0.01f);
    }
}
