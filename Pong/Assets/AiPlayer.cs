using UnityEngine;
using System.Collections;

public class AiPlayer : MonoBehaviour {

	private PaddleControler paddle;
	private Transform ball;

	void Start () {
		paddle = GetComponent<PaddleControler>();
		ball = GameObject.FindWithTag("Ball").transform;
	}
	
	void Update () {
		if (transform.position.y > ball.position.y) {
			paddle.MoveDown();
		}

		if (transform.position.y < ball.position.y) {
			paddle.MoveUp();
		}
	}
}
