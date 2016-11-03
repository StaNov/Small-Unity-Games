using UnityEngine;
using System.Collections;

public abstract class AbstractPlayer : MonoBehaviour {

	[SerializeField]
	protected Hand m_Hand;
		
	void Update () {
		switch (GameBoard.State) {
			case GameBoard.GameBoardState.WaitingForFirstCard:
				PlayFirstCardIfPossible();
				break;
			case GameBoard.GameBoardState.WaitingForNextPlayerToPlay:
				if (GameBoard.CurrentPlayerIndex == m_MyIndex) {
					Play(GameBoard.PlayedCards);
				}
				break;
		}
		
	}

	protected abstract void PlayFirstCardIfPossible();
	protected abstract void Play(Card[] cardsAlreadyPlayed);

	protected void PlayCard(Card card) {
		GameBoard.AcceptPlayedCard(card, m_MyIndex);
	}


	/* TODO how to not duplicate code in Player? */
	private int m_MyIndex { get { return transform.GetSiblingIndex(); } }
}
