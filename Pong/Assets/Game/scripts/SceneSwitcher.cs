using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {
	
	public void PlayAgain() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void BackToMenu() {
		Application.LoadLevel(0);
	}
}
