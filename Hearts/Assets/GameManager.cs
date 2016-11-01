using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

	void Start () {
		DealCards();
		GameBoard.StartGame();
	}

	private void DealCards() {
		Players.Playerz[0].DealCards();
	}
}
