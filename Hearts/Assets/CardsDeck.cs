using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CardsDeck : MonoBehaviour {
	
	private static CardsDeck m_Instance;

	public static Card[] CardsInDeck { get { return GetCards(); } }

	private static Card[] GetCards() {
		return m_Instance.transform.GetComponentsInChildren<Card>();
	}
	
	void Awake () {
		m_Instance = this;

		CreateCards();
		ShuffleCards();
	}

	private void CreateCards() {
		foreach (Card.CardType type in Enum.GetValues(typeof(Card.CardType))) {
			foreach (Card.CardValue value in Enum.GetValues(typeof(Card.CardValue))) {
				var newCardObject = new GameObject();
				Card newCard = newCardObject.AddComponent<Card>();
				newCard.Type = type;
				newCard.Value = value;
				newCardObject.name = newCard.ToString();
				newCardObject.transform.parent = this.transform;
			}
		}
	}

	private void ShuffleCards() {
		List<Card> remainings = new List<Card>(CardsInDeck);

		var random = new System.Random();

		while (remainings.Count > 0) {
			int index = random.Next(0, remainings.Count);
			remainings[index].transform.SetAsFirstSibling();
			remainings.RemoveAt(index);
		}
	}
}
