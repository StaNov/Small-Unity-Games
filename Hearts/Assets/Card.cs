using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public CardType Type { get { return m_Type; } set { SetType(value); } }
	public CardValue Value { get { return m_Value; } set { SetValue(value); } }

	private CardType m_Type;
	private CardValue m_Value;
	private bool m_TypeSet = false;
	private bool m_ValueSet = false;

	public override string ToString() {
		if (!m_TypeSet || !m_ValueSet) {
			Debug.LogError("Card not initialized yet!");
			return "";
		}

		return string.Format("Card{0}{1}", m_Type.ToString(), m_Value.ToString());
	}

	public enum CardType {
		Clubs,
		Spades,
		Diamonds,
		Hearts
	}

	public enum CardValue {
		V7,
		V8,
		V9,
		V10,
		Jack,
		Queen,
		King,
		Ace
	}

	private void SetType(CardType type) {
		if (m_TypeSet) {
			Debug.LogError("Type has been already set!");
			return;
		}

		m_Type = type;
		m_TypeSet = true;
	}

	private void SetValue(CardValue value) {
		if (m_ValueSet) {
			Debug.LogError("Value has been already set!");
			return;
		}

		m_Value = value;
		m_ValueSet = true;
	}
}
