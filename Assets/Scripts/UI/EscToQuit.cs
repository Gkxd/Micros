using UnityEngine;
using System.Collections;

public class EscToQuit : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}
}
