using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

	void Start () {
		DealCards();
	}

	private void DealCards() {
		Players.Playerz[0].DealCards();
	}
}
