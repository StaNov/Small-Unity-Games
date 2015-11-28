using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {

	public void StartGame() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
