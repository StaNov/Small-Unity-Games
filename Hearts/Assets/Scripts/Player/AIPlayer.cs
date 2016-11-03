using UnityEngine;
using System.Collections;

public class AIPlayer : AbstractPlayer {

	protected override void PlayFirstCardIfPossible() {
		Card diamondQueen = m_Hand.GetDiamondQueenIfInHand();

		if (diamondQueen != null) {
			PlayCard(diamondQueen);
		}
	}

	protected override void Play(Card[] cardsAlreadyPlayed) {
		PlayCard(m_Hand.Cards[0]); // TODO
	}
}
