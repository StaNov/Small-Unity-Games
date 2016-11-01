using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Hand m_Hand;

	public int PlayerIndex { get; private set; }

	void Awake() {
		PlayerIndex = transform.GetSiblingIndex();
	}

	void Update() {
		switch (GameBoard.State) {
			// TODO move to AI
			case GameBoard.GameBoardState.WaitingForFirstCard:
				PlayFirstCardIfPossible();
				break;
		}
	}

	public void DealCards() {
		Card[] cardsToDeal = CardsDeck.CardsInDeck;

		if (cardsToDeal.Length == 0) {
			Debug.LogError("Deck is empty!");
			return;
		}

		int currentPlayerIndex = PlayerIndex;

		foreach (Card card in cardsToDeal) {
			currentPlayerIndex = (currentPlayerIndex + 1) % Players.Playerz.Length;

			Players.Playerz[currentPlayerIndex].AcceptCardFromDealer(card);
		}
	}

	public void AcceptCardFromDealer(Card card) {
		m_Hand.Add(card);
	}

	private void PlayFirstCardIfPossible() {
		Card diamondQueen = m_Hand.GetDiamondQueenIfInHand();

		if (diamondQueen != null) {
			GameBoard.AcceptPlayedCard(diamondQueen, PlayerIndex);
		}
	}
}
