using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform initialPosition;

    public int coinsAmount;
    
    public AudioClip coinCollectSfx;

    public static GameManager Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    private void Start() {

        if (Player.Instance != null) {
            Player.Instance.GetComponent<CharacterController>().enabled = false;
            Player.Instance.transform.position = initialPosition.position;
            Player.Instance.GetComponent<CharacterController>().enabled = true;
            
            Player.Instance.isPaused = false;
            Player.Instance.playerHUD.ActivateCanvas(true);
            CinemachineController.Instance.AssignToPlayer();
        }
    }

    public void CoinKept() {
        AudioManager.Instance.PlaySFX(coinCollectSfx);
        coinsAmount++; // TOO: mover logica para componenteResponsavel
        Player.Instance.playerHUD.DefineCoinsAmount(coinsAmount);
    }
}
