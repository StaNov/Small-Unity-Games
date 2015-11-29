using UnityEngine;
using System.Collections;

public class MaximumLevelManager : MonoBehaviour {

	private static string MAX_LEVEL_KEY = "maxLevel";

	public static void SaveMaxLevel(int level) {
		if (level > GetMaxLevel()) {
			PlayerPrefs.SetInt(MAX_LEVEL_KEY, level);
		}
	}

	public static int GetMaxLevel() {
		return PlayerPrefs.GetInt(MAX_LEVEL_KEY, 0);
	}
}
