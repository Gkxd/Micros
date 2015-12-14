using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public GameObject player;
    public GameObject HUD;
    public GameObject titleScreen;

    void Update() {
        if (Input.anyKeyDown) {
            player.SetActive(true);
            HUD.SetActive(true);

            titleScreen.SetActive(false);
        }
    }
}
