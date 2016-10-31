using UnityEngine;
using System.Collections;
using System;

public class CardsDeck : MonoBehaviour {
	
	void Start () {
		CreateCards();
	}
	
	void Update () {

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
}
