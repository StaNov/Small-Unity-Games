using UnityEngine;
using System.Collections;

public class BallSoundPlayer : MonoBehaviour {

    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

	void OnCollisionEnter(Collision col) {
        source.Play();
    }
}
