using UnityEngine;
using System.Collections;

public class HumanPlayer : AbstractPlayer {

	protected override void PlayFirstCardIfPossible() {
		if (m_Hand.GetDiamondQueenIfInHand() == null) {
			return;
		}

		EnableCardsClicking();
	}

	protected override void Play(Card[] cardsAlreadyPlayed) {
		EnableCardsClicking();
	}

	private void EnableCardsClicking() {
		m_Hand.SetClickingOnCardsEnabled((card) => PlayClickedCard(card));
	}
	
	private void PlayClickedCard(Card card) {
		m_Hand.SetClickingOnCardsDisabled();
		PlayCard(card);
	}
}
