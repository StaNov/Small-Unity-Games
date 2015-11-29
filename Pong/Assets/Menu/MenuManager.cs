using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void StartEasyMatch() {
		MenuSettings.Instance().difficulty = Difficulty.EASY;
		LoadGame();
	}

	public void StartMediumMatch() {
		MenuSettings.Instance().difficulty = Difficulty.MEDIUM;
		LoadGame();
	}
	
	public void StartHardMatch() {
		MenuSettings.Instance().difficulty = Difficulty.HARD;
		LoadGame();
	}
	
	public void StartPlayerVsPlayer() {
		MenuSettings.Instance().difficulty = Difficulty.PVP;
		LoadGame();
	}

	private void LoadGame() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void Exit() {
		Application.Quit();
	}
}
