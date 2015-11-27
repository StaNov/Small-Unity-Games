using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager instance = null;

	public int pointsToWin = 5;

    private Text textLeft;
    private Text textRight;

    private int scoreLeft;
    private int scoreRight;

	private GameObject winTextLeft;
	private GameObject winTextRight;
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
		textLeft = transform.FindChild("Score Left").GetComponent<Text>();
		textRight = transform.FindChild("Score Right").GetComponent<Text>();
		winTextLeft = transform.Find("Game over text/Left won").gameObject;
		winTextRight = transform.Find("Game over text/Right won").gameObject;
		buttons = transform.Find("Buttons").gameObject;

        scoreLeft = 0;
        scoreRight = 0;
		winTextLeft.SetActive(false);
		winTextRight.SetActive(false);
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
					winTextRight.SetActive(true);
					result = true;
				}
                break;

            case PlayerSide.Right:
				scoreLeft++;
				if (scoreLeft >= pointsToWin) {
					winTextLeft.SetActive(true);
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
