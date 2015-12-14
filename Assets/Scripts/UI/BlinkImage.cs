using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkImage : MonoBehaviour {

    public Image renderer;

    void Start() {
        StartCoroutine(blink());
    }

    void OnEnable() {
        StartCoroutine(blink());
    }

    private IEnumerator blink() {
        yield return new WaitForSeconds(Random.Range(2, 6));
        while (true) {
            int blinkAmount = Random.Range(1, 3);
            for (int i = 0; i < blinkAmount; i++) {
                renderer.enabled = false;
                yield return new WaitForSeconds(0.05f);
                renderer.enabled = true;
            }

            yield return new WaitForSeconds(Random.Range(2, 6));
        }
    }
}
