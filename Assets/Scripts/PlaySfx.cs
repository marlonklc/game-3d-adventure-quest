using UnityEngine;

public class PlaySfx : MonoBehaviour {
    
    public AudioSource audioSource;

    public void PlaySFX(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }
}
