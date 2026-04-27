using System;
using UnityEngine;

public class FadeController : MonoBehaviour {
    
    public Animator animator;
    public bool fadeOut;

    private void Start() {
        if (fadeOut) {
            animator.Play("fadeOut");
            return;
        }
        
        animator.Play("fadeIn");
    }
}
