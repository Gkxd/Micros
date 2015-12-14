using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class ChangeColorWithCurve : MonoBehaviour {

    public Gradient color;
    public AnimationCurve curve;

    private Material m;
    private float startTime;

    void Start() {
        m = GetComponent<Renderer>().material;
        startTime = Time.time;
    }


    void Update() {
        m.SetColor("_Color", color.Evaluate(curve.Evaluate(Time.time - startTime)));
    }
}
