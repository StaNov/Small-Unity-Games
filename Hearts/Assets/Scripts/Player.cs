using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool IsHumanPlayer = false;

	[SerializeField]
	private Hand m_Hand;

	public int PlayerIndex { get; private set; }

	void Awake() {
		PlayerIndex = transform.GetSiblingIndex();
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
		
		card.Shown = IsHumanPlayer;
	}
}
