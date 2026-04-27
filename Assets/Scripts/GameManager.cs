using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform initialPosition;

    public int coinsAmount;

    public static GameManager Instance;

    private void Awake() {
        Instance = this;
    }

    private void Start() {

        if (Player.Instance != null) {
            Player.Instance.transform.position = initialPosition.position;
            Player.Instance.isPaused = false;
            
            Player.Instance.playerHUD.ActivateCanvas(true);
            CinemachineController.Instance.AssignToPlayer();
        }
    }

    public void CoinKept() {
        coinsAmount++; // TOO: mover logica para componenteResponsavel
        Player.Instance.playerHUD.DefineCoinsAmount(coinsAmount);
    }
}
