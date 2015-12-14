using UnityEngine;
using System.Collections;

public class SfxManager : MonoBehaviour {

    public static SfxManager instance;

    public AudioSource audioSource;

    public AudioClip sfxSplit;
    public AudioClip sfxHurt;
    public AudioClip sfxEat;

	void Start () {
        instance = this;
	}

    public static void PlaySfxSplit() {
        instance.audioSource.PlayOneShot(instance.sfxSplit);
    }

    public static void PlaySfxHurt() {
        instance.audioSource.PlayOneShot(instance.sfxHurt);
    }

    public static void PlaySfxEat() {
        instance.audioSource.PlayOneShot(instance.sfxEat);
    }
}
