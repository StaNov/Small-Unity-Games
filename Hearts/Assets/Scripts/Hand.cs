using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	public Card[] Cards { get { return transform.GetComponentsInChildren<Card>(); } }
	
	public void Add (Card card) {
		card.transform.parent = this.transform;
	}

	public Card GetDiamondQueenIfInHand() {
		foreach (Card card in Cards) {
			if (card.Type == Card.CardType.Diamonds && card.Value == Card.CardValue.Queen) {
				return card;
			}
		}

		return null;
	}
}
