using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGame : MonoBehaviour {

    public GameObject fadeToBlack;

    public float lifeTime;

    void Update() {

        lifeTime += Time.deltaTime;

        if (lifeTime > 2) {
            if (Input.anyKeyDown) {
                StartCoroutine(restart());
            }
        }
    }

    private IEnumerator restart() {
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        TrackColonySize.hasGameStarted = false;
        ScoreManager.score = 0;
        SceneManager.LoadScene(0);
    }
}
