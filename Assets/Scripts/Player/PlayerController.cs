using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public static Transform playerInstance;

    public new Rigidbody rigidbody;
    public float moveSpeed;

    void Start() {
        playerInstance = transform;
    }

    void FixedUpdate() {
        if (ShowHelp.helpActive) {
            rigidbody.Sleep();
            return;
        }

        if (TrackColonySize.colonySize > 0) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, vertical, 0);
            if (direction.sqrMagnitude > 1) {
                direction.Normalize();
            }

            rigidbody.velocity = direction * moveSpeed;
        }
        else {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
