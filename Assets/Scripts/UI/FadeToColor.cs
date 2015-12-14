using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeToColor : MonoBehaviour {
    public Color fadeColor;
    private Image image;
    void Start() {
        image = GetComponent<Image>();
    }

    void Update() {
        image.color = Color.Lerp(image.color, fadeColor, Time.deltaTime * 2);
    }
}
