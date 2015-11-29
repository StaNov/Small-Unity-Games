using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager instance = null;

	public int pointsToWin = 5;
	public int levelNumber = 0;

    private Text textLeft;
    private Text textRight;

    private int scoreLeft;
    private int scoreRight;

	private Text winTextLeft;
	private Text winTextRight;
	private GameObject buttons;

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
		textLeft = GameObject.Find("Score Left").GetComponent<Text>();
		textRight = GameObject.Find("Score Right").GetComponent<Text>();
		winTextLeft = transform.Find("Game over text/Left won").GetComponent<Text>();
		winTextRight = transform.Find("Game over text/Right won").GetComponent<Text>();
		buttons = transform.Find("Buttons").gameObject;

        scoreLeft = 0;
        scoreRight = 0;
		winTextLeft.enabled = false;
		winTextRight.enabled = false;
		buttons.SetActive(false);
        UpdateScores();
    }

	/**
	 * Returns true if game is over.
	 */
    public bool AddPoint(PlayerSide side) {
		bool result = false;

        switch (side) {
            case PlayerSide.Left:
                scoreRight++;
			    if (scoreRight >= pointsToWin) {
					winTextRight.enabled = true;
					result = true;
					MaximumLevelManager.SaveMaxLevel(levelNumber);
				}
                break;

            case PlayerSide.Right:
				scoreLeft++;
				if (scoreLeft >= pointsToWin) {
					winTextLeft.enabled = true;
					result = true;
				}
                break;
            default:
                Debug.LogError("Side not specified!");
                break;
        }

        UpdateScores();

		if (result) {
			buttons.SetActive(true);
		}

		return result;
    }

    private void UpdateScores() {
        textLeft.text = "" + scoreLeft;
        textRight.text = "" + scoreRight;
    }
}
