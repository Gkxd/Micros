using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetRenderQueue : MonoBehaviour {

    public int renderQueue;
	void Start () {
        GetComponent<Renderer>().sharedMaterial.renderQueue = renderQueue;
	}
}
