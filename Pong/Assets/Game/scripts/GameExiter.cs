using UnityEngine;
using System.Collections;

public class GameExiter : MonoBehaviour {
    
	void Update () {
	    if (Input.GetAxis("Exit") > 0) {
            Application.Quit();
        }
	}
}
