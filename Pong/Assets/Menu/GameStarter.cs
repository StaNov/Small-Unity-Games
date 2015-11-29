using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {

	public void StartEasyMatch() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void StartMediumMatch() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void StartHardMatch() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void StartPlayerVsPlayer() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
