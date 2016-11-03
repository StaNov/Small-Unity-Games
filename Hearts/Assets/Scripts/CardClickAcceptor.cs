using UnityEngine;
using System.Collections;

public class CardClickAcceptor : MonoBehaviour {

	public bool ClickingEnabled = false;
	
	void OnMouseDown () {
		if (!ClickingEnabled) {
			return;
		}

		GetComponentInParent<HumanPlayer>().PlayClickedCard(GetComponent<Card>()); // TODO how to design better?
	}
	
}
