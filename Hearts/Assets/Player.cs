using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Hand Hand { get { return m_Hand; } }

	[SerializeField]
	private Hand m_Hand;

	public void DealCards() {
		Card[] cardsToDeal = CardsDeck.CardsInDeck;

		if (cardsToDeal.Length == 0) {
			Debug.LogError("Deck is empty!");
			return;
		}

		int currentPlayerIndex = MyIndex;

		foreach (Card card in cardsToDeal) {
			currentPlayerIndex = (currentPlayerIndex + 1) % Players.Playerz.Length;

			Players.Playerz[currentPlayerIndex].Hand.AcceptCard(card);
		}
	}

	private int MyIndex { get { return transform.GetSiblingIndex(); } }
}
