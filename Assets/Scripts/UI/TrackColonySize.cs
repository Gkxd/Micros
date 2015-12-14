using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrackColonySize : MonoBehaviour {
    private static TrackColonySize instance;
    public static bool hasGameStarted { get; set; }

    public static int colonySize { get; private set; }

    public Text text;
    public GameObject gameOver;

    void Start() {
        instance = this;
        colonySize = 1;
        hasGameStarted = true;
    }

    public static void add() {
        colonySize++;
        instance.text.text = colonySize + "/20";
    }

    public static void remove() {
        colonySize--;
        instance.text.text = colonySize + "/20";

        if (colonySize == 0) {
            instance.gameOver.SetActive(true);
        }
    }
}
