using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

    private static float BALL_SPAWN_POSITION_X = 0;

	public float startingBallSpeed = 10f;

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

        ball.position = new Vector3(BALL_SPAWN_POSITION_X, Random.Range(-10f, 10f), ball.position.z);
        ballRigidBody.velocity = Vector3.zero;
    }

	public void KickBall(PlayerSide targetSide) {
		Rigidbody ballRigidBody = ball.GetComponent<Rigidbody>();
		Vector3 force = new Vector3(startingBallSpeed, startingBallSpeed, 0);
		
		if (targetSide == PlayerSide.Left) {
			force = new Vector3(-force.x, force.y, force.z);
		}
		
		if (Random.value > 0.5) {
			force = new Vector3(force.x, -force.y, force.z);
		}
		
		ballRigidBody.AddForce(force, ForceMode.Impulse);
	}

    public void AddPointAndSpawnNewBall(PlayerSide player) {
        bool gameOver = scoreManager.AddPoint(player);

		if (! gameOver) {
			ResetBall();
			KickBall(player == PlayerSide.Left ? PlayerSide.Right : PlayerSide.Left);
		} else {
			ball.gameObject.SetActive(false);
		}
    }
}
