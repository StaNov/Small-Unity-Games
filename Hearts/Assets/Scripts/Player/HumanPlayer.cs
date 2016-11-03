using UnityEngine;
using System.Collections;

public class HumanPlayer : AbstractPlayer {

	protected override void PlayFirstCardIfPossible() {
		if (m_Hand.GetDiamondQueenIfInHand() == null) {
			return;
		}
		
		m_Hand.SetClickingOnCardsEnabled(true);
	}

	protected override void Play(Card[] cardsAlreadyPlayed) {
		m_Hand.SetClickingOnCardsEnabled(true);
	}

	// TODO design better, this is spaghetti
	public void PlayClickedCard(Card card) {
		m_Hand.SetClickingOnCardsEnabled(false);
		PlayCard(card);
	}
}
