using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class ChangeImageColorWithCurve : MonoBehaviour {

    public Gradient color;
    public AnimationCurve curve;

    private Image m;
    private float startTime;

    void Start() {
        m = GetComponent<Image>();
        startTime = Time.time;
    }

    void Update() {
        m.color = color.Evaluate(curve.Evaluate(Time.time - startTime));
    }
}
