using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class ChangeUITextColorWithCurve : MonoBehaviour {

    public Gradient color;
    public AnimationCurve curve;

    private Text t;
    private float startTime;

    void Start() {
        t = GetComponent<Text>();
        startTime = Time.time;
    }


    void Update() {
        t.color = color.Evaluate(curve.Evaluate(Time.time - startTime));
    }
}
