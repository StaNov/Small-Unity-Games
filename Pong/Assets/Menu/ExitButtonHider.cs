using UnityEngine;
using System.Collections;

public class ExitButtonHider : MonoBehaviour {
	
#if (UNITY_WEBGL || UNITY_WEBPLAYER) && !UNITY_EDITOR
	void Start () {
		Destroy(GameObject.Find("Exit"));
		Destroy(GameObject.Find("space exit"));
	}
#endif
}
