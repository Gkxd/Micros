using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetFullscreenQuad : MonoBehaviour {
    void Start() {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Camera.main.aspect;

        transform.localScale = new Vector3(width, height, 1);
    }
}
