using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CardsDeck : MonoBehaviour {

	private List<Card> m_Cards;
	private static CardsDeck m_Instance;

	public static List<Card> CardsInDeck { get { return GetCards(); } }

	private static List<Card> GetCards() {
		var result = new List<Card>(m_Instance.m_Cards);
		m_Instance.m_Cards.Clear();

		return result;
	}
	
	void Awake () {
		m_Instance = this;
		m_Cards = new List<Card>(32);

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
				m_Cards.Add(newCard);
			}
		}
	}

	private void ShuffleCards() {
		List<Card> shuffled = new List<Card>(32);

		var random = new System.Random();

		while (m_Cards.Count > 0) {
			int index = random.Next(0, m_Cards.Count);
			shuffled.Add(m_Cards[index]);
			m_Cards.RemoveAt(index);
		}

		for (int i = 0; i < shuffled.Count; i++) {
			m_Cards.Add(shuffled[i]);
		}
	}
}
