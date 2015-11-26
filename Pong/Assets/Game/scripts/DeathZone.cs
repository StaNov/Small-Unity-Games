using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    public PlayerSide playerSide;
    private BallManager ballManager;

    void Start() {
        ballManager = BallManager.GetInstance();
    }

    void OnCollisionEnter(Collision col) {
        ballManager.AddPointAndSpawnNewBall(playerSide);
    }
}
