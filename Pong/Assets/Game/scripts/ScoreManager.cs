using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager instance = null;

    private Text textLeft;
    private Text textRight;

    private int scoreLeft;
    private int scoreRight;

    public static ScoreManager GetInstance() {
        return instance;
    }

    void Awake() {
        if (instance != null) {
            Debug.LogError("Instance already created!");
        }
        instance = this;
    }

    void Start() {
        Text[] texts = FindObjectsOfType<Text>();
        textLeft = texts[0];
        textRight = texts[1];
        scoreLeft = 0;
        scoreRight = 0;
        UpdateScores();
    }

    public void AddPoint(PlayerSide side) {
        switch (side) {
            case PlayerSide.Left:
                scoreRight++;
                break;

            case PlayerSide.Right:
                scoreLeft++;
                break;
            default:
                Debug.LogError("Side not specified!");
                break;
        }

        UpdateScores();
    }

    private void UpdateScores() {
        textLeft.text = "" + scoreLeft;
        textRight.text = "" + scoreRight;
    }
}
