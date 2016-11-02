using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CardsDeck : MonoBehaviour {
	
	private static CardsDeck m_Instance;

	[SerializeField]
	private GameObject m_CardPrefab;

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
				var newCardObject = Instantiate(m_CardPrefab, this.transform) as GameObject;
				Card newCard = newCardObject.AddComponent<Card>();
				newCard.Type = type;
				newCard.Value = value;
				newCardObject.name = newCard.ToString();
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
