using UnityEngine;
using System.Collections;
using System;

public class CardClickAcceptor : MonoBehaviour {

	public Action<Card> OnCardClick = null;

	[SerializeField]
	private Card m_Card;
	
	void OnMouseDown () {
		if (OnCardClick == null) {
			return;
		}

		OnCardClick(m_Card);
	}
	
}
