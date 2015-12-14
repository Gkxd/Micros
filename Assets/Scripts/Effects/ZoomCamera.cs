using UnityEngine;
using System.Collections;

public class ZoomCamera : MonoBehaviour {

    public Camera camera;

    private float targetOrthographicScale, orthographicScale;

    void Start() {
        orthographicScale = targetOrthographicScale = camera.orthographicSize;
    }

    void Update() {
        targetOrthographicScale = 10 + (TrackColonySize.colonySize - 1) / 2;
        orthographicScale = Mathf.Lerp(orthographicScale, targetOrthographicScale, Time.deltaTime);
        camera.orthographicSize = orthographicScale;
    }
}
