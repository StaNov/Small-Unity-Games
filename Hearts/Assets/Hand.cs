using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
	
	public void AcceptCard (Card card) {
		card.transform.parent = this.transform;
	}
}
