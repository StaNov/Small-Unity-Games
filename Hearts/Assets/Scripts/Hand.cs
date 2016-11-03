using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	public Card[] Cards { get { return transform.GetComponentsInChildren<Card>(); } }
	
	[SerializeField]
	private Transform[] m_CardSlots;
	
	public void Add (Card card) {
		foreach (Transform slot in m_CardSlots) {
			if (slot.childCount == 0) {
				card.transform.parent = slot;
				return;
			}
		}
	}

	public Card GetDiamondQueenIfInHand() {
		foreach (Card card in Cards) {
			if (card.Type == Card.CardType.Diamonds && card.Value == Card.CardValue.Queen) {
				return card;
			}
		}

		return null;
	}

	public void SetClickingOnCardsEnabled(bool enabled) {
		foreach (var acceptor in GetComponentsInChildren<CardClickAcceptor>()) {
			acceptor.ClickingEnabled = enabled;
		}
	}
}
