using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour {
    
    public TextMeshProUGUI coinsAmountText;
    public Canvas canvas;
    public Canvas inventoryCanvas;

    public void DefineCoinsAmount(int coinsAmount) {
        coinsAmountText.text = coinsAmount.ToString();
    }
    
    public void ActivateCanvas(bool active) {
        canvas.enabled = active;
    }
}
