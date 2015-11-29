using UnityEngine;
using System.Collections;

public class MenuSettings : MonoBehaviour {

	public Difficulty difficulty = Difficulty.PVP;

	private static MenuSettings instance;

	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(this);
		}
	}

	public static MenuSettings Instance() {
		return instance;
	}
}

public enum Difficulty {
	PVP, EASY, MEDIUM, HARD
}
