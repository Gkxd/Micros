using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager instance;

    public Text text;
    public Text finalScore;

    public static int score;

    private float timeScore;
    private int displayScore;
    private int totalScore;

    void Start() {
        instance = this;
    }

    void Update() {
        if (TrackColonySize.colonySize > 0) {
            timeScore += Time.deltaTime;
        }

        totalScore = score + (int)timeScore;
        if (displayScore < totalScore) {
            displayScore += increaseAmount(totalScore - displayScore);

            if (displayScore > totalScore) {
                displayScore = totalScore;
            }

            text.text = "" + displayScore;
        }
        finalScore.text = "Final Score\n" + totalScore;
    }

    private int increaseAmount(int i) {
        return i / 100 + 1;
    }
}
