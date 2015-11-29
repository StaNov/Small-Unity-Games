using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemsEnabler : MonoBehaviour {

	public Button mediumMatch;
	public Button hardMatch;
	public GameObject trophy;

	void Start () {
		trophy.SetActive(false);
		int maximumLevel = MaximumLevelManager.GetMaxLevel();

		if (maximumLevel >= 1) {
			mediumMatch.interactable = true;
		}
		
		if (maximumLevel >= 2) {
			hardMatch.interactable = true;
		}
		
		if (maximumLevel >= 3) {
			trophy.SetActive(true);
		}
	}
}
