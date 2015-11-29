using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void StartEasyMatch() {
		Application.LoadLevel("easyMatch");
	}

	public void StartMediumMatch() {
		Application.LoadLevel("mediumMatch");
	}
	
	public void StartHardMatch() {
		Application.LoadLevel("hardMatch");
	}
	
	public void StartPlayerVsPlayer() {
		Application.LoadLevel("pvp");
	}

	public void Exit() {
		Application.Quit();
	}
}
