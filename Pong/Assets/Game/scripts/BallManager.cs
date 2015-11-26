using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

    private static float BALL_SPAWN_POSITION_X = 0;
    private static float BALL_SPAWN_POSITION_Y = 0;

    private static BallManager instance = null;

    private ScoreManager scoreManager;
    private Transform ball;

    public static BallManager GetInstance() {
        return instance;
    }

    void Awake() {
        if (instance != null) {
            Debug.LogError("Instance already created!");
        }

        instance = this;
    }

    void Start() {
        scoreManager = ScoreManager.GetInstance();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        ResetBall();
    }

    public void ResetBall() {
        Rigidbody ballRigidBody = ball.GetComponent<Rigidbody>();

        ball.position = new Vector3(BALL_SPAWN_POSITION_X, BALL_SPAWN_POSITION_Y, ball.position.z);
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.AddForce(new Vector3(10, 10, 0), ForceMode.Impulse);
    }

    public void AddPointAndSpawnNewBall(PlayerSide player) {
        bool gameOver = scoreManager.AddPoint(player);

		if (! gameOver) {
			ResetBall();
		} else {
			ball.gameObject.SetActive(false);
		}
    }
}
