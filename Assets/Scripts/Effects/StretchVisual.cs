using UnityEngine;
using System.Collections;

public class StretchVisual : MonoBehaviour {
    public new Rigidbody rigidbody;

    public Renderer renderer;

    [Range(0, 60)]
    public float stretchSpeed;

    public AnimationCurve stretchCurveX;
    public AnimationCurve stretchCurveY;

    private float stretch;
    private float targetStretch;

    private Vector3 velocity;

	void Update () {
        Vector3 targetVelocity = rigidbody.velocity;
        if (targetVelocity.sqrMagnitude > 0.01) {
            velocity = Vector3.Slerp(velocity, targetVelocity, Time.deltaTime * 10);
        }

        float angle = Mathf.Atan2(velocity.y, velocity.x);

        //renderer.material.SetFloat("_ScaleAngle", angle);
        
        targetStretch = velocity.magnitude / 2.5f;
        stretch = Mathf.Lerp(stretch, targetStretch, Time.deltaTime * Random.Range(0, stretchSpeed));

        //Vector4 scale = new Vector4(stretchCurveX.Evaluate(stretch), stretchCurveY.Evaluate(stretch), 1, 1);

        transform.localScale = new Vector3(stretchCurveX.Evaluate(stretch), stretchCurveY.Evaluate(stretch), 1);
        transform.eulerAngles = Vector3.forward * angle * Mathf.Rad2Deg;


        //renderer.material.SetVector("_Scale", scale);
	}
}
