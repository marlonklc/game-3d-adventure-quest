using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    
    public void PlayBGM(AudioClip clip) {
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        sfxSource.PlayOneShot(clip);
    }
}
