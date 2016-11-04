using UnityEngine;
using System.Collections;

public class TakenCards : MonoBehaviour {

	public Card[] Cards { get { return GetComponentsInChildren<Card>(); } }

	public void AcceptCards(Card[] cards) {
		foreach (Card card in cards) {
			card.Shown = false;
			card.transform.parent = this.transform;
		}
	}

	
}
