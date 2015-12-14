using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {

    public Transform referenceTransform;

    private Material material;
    private Vector2 offset, targetOffset;

    void Start() {
        material = GetComponent<Renderer>().material;
    }

    void Update() {
        float depth = Mathf.Max(1, transform.localPosition.z);

        targetOffset = new Vector2(referenceTransform.position.x / (70 + 10 * depth), referenceTransform.position.y / (70 + 10 * depth));
        offset = Vector2.Lerp(offset, targetOffset, Time.deltaTime * 2);
        material.SetTextureOffset("_MainTex", offset);
    }
}
