using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour {

	private const int NUMBER_OF_PLAYERS = 4;
	private const int ROUNDS = 8;

	private static GameBoard m_Instance;

	public static GameBoardState State { get { return m_Instance.m_State; } }
	public static int CurrentPlayerIndex { get { return m_Instance.m_CurrentPlayerIndex; } }
	public static Card[] PlayedCards { get { return m_Instance.GetComponentsInChildren<Card>(); } }

	private GameBoardState m_State;
	private int m_CurrentPlayerIndex;
	private int m_RoundNumber;
	
	[SerializeField]
	private GameObject[] m_PlayedCardsSlots;

	
	void Awake () {
		m_Instance = this;
		m_State = GameBoardState.GameStopped;
	}

	public static void StartGame() {
		m_Instance.m_CurrentPlayerIndex = -1;
		m_Instance.m_State = GameBoardState.WaitingForFirstCard;
		m_Instance.m_RoundNumber = 1;
	}

	void Update() {
		switch (State) {
			case GameBoardState.WaitingForPlayerTakingCardsFromGameBoard:
				if (PlayedCards.Length == 0) {
					if (m_Instance.m_RoundNumber < ROUNDS) {
						m_Instance.m_State = GameBoardState.WaitingForNextPlayerToPlay;
						m_Instance.m_RoundNumber++;
					}
					else
					{
						m_Instance.m_State = GameBoardState.GameStopped; // TODO calculate points, return cards to deck, deal cards, start new game
					}
					
				}
				break;
		}
	}

	public static void AcceptPlayedCard(Card card, int playerIndex) {
		Debug.LogFormat("Player {0} played {1}", playerIndex, card);

		if (!m_Instance.IsValidMove(card, playerIndex)) {
			Debug.LogError("INVALID MOVE!");
		}

		card.Shown = true;
		card.transform.parent = m_Instance.m_PlayedCardsSlots[playerIndex].transform;
		m_Instance.m_CurrentPlayerIndex = (playerIndex + 1) % NUMBER_OF_PLAYERS;

		if (PlayedCards.Length == NUMBER_OF_PLAYERS) {
			m_Instance.m_State = GameBoardState.WaitingForPlayerTakingCardsFromGameBoard;
			m_Instance.m_CurrentPlayerIndex = m_Instance.PlayerWhoShouldTakeCardsFromGameBoard();
		}
		else {
			m_Instance.m_State = GameBoardState.WaitingForNextPlayerToPlay;
		}
	}

	private bool IsValidMove(Card card, int playerIndex) {
		if (m_State == GameBoardState.GameStopped) {
			return false;
		}

		if (m_State == GameBoardState.WaitingForFirstCard && card.IsFirstCard) {
			return true;
		}

		if (m_State == GameBoardState.WaitingForNextPlayerToPlay && playerIndex != m_CurrentPlayerIndex) {
			return false;
		}

		return true; // TODO add other rules
	}

	private int PlayerWhoShouldTakeCardsFromGameBoard() {
		return new System.Random().Next(0, 4); // TODO, write tests
	}

	public enum GameBoardState {
		GameStopped,
		WaitingForFirstCard,
		WaitingForNextPlayerToPlay,
		WaitingForPlayerTakingCardsFromGameBoard
	}
}
