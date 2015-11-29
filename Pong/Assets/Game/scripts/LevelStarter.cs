using UnityEngine;
using System.Collections;

public class LevelStarter : MonoBehaviour {

	public void StartLevel() {
		BallManager.GetInstance().KickBall(PlayerSide.Left);
	}
}
