using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationManager : MonoBehaviour {
    private void Start() {
        Player.Instance.playerHUD.ActivateCanvas(false);
    }

    public void PlayGame() {
        SceneManager.LoadScene("gameplay");
    }
    
}

public enum BodyType {
    head,
    hair,
    body,
    hat,
    eye,
    mustache,
    mouth,
    accessory,
    gender,
}
