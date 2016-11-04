using UnityEngine;
using System.Collections;

public abstract class AbstractPlayer : MonoBehaviour {

	[SerializeField]
	protected Hand m_Hand;

	[SerializeField]
	protected TakenCards m_TakenCards;

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
			case GameBoard.GameBoardState.WaitingForPlayerTakingCardsFromGameBoard:
				if (GameBoard.CurrentPlayerIndex == m_MyIndex) {
					TakeCardsFromGameBoard();
				}
				break;
		}
		
	}

	protected abstract void PlayFirstCardIfPossible();
	protected abstract void Play(Card[] cardsAlreadyPlayed);

	protected void PlayCard(Card card) {
		GameBoard.AcceptPlayedCard(card, m_MyIndex);
	}

	private void TakeCardsFromGameBoard() {
		m_TakenCards.AcceptCards(GameBoard.PlayedCards);
	}


	/* TODO how to not duplicate code in Player? */
	private int m_MyIndex { get { return transform.GetSiblingIndex(); } }
}
