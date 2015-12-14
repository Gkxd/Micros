using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

    public Transform playerTransform;

    Vector3 offset;
    Vector3 position;

    void Start() {
        offset = transform.position - playerTransform.position;
        position = transform.position;
    }

    void Update() {
        position = Vector3.Lerp(position, playerTransform.position + offset, Time.deltaTime * 2);
        transform.position = position;
    }
}
