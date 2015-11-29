using UnityEngine;
using System.Collections;

public class MouseHider : MonoBehaviour {

	void Awake () {
		UnityEngine.Cursor.visible = false;
	}
}
