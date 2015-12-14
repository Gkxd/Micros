using UnityEngine;
using System.Collections;

public class KeepOneInstance : MonoBehaviour {
    public static GameObject instance;
    void Start() {
        if (instance) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
            instance = gameObject;
        }
    }
}
