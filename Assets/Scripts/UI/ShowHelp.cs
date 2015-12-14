using UnityEngine;
using System.Collections;

public class ShowHelp : MonoBehaviour {
    public GameObject help;

    public static bool helpActive;

    void Start() {
        helpActive = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            help.SetActive(helpActive = !helpActive);
            //Time.timeScale = helpActive ? 0 : 1;
        }
    }
}
