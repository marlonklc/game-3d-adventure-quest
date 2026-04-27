using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationSlot : MonoBehaviour {

    public BodyType type;
    
    private int currentIndex = 0;
    private int totalParts = 0;

    public Sprite sprite;
    public Image iconImage;
    
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI amountText;

    private void Start() {
        bodyText.text = type.ToString();
        
        iconImage.sprite = sprite;
        
        UpdateParts();
    }

    public void Next() {
        currentIndex++;

        if (currentIndex >= totalParts) currentIndex = 0;
        
        UpdateParts();
    }
    
    public void Previous() {
        currentIndex--;
        
        if (currentIndex < 0) currentIndex = totalParts - 1;
        
        UpdateParts();
    }

    private void UpdateParts() {

        foreach (var bodyPart in Player.Instance.playerCustomizationBody.bodyParts) {
            if (bodyPart.type == type) {
                totalParts = bodyPart.parts.Count;

                for (int i = 0; i < bodyPart.parts.Count; i++) {
                    bodyPart.parts[i].SetActive(i == currentIndex);
                }
            }
        }
        
        amountText.text = (currentIndex + 1) + "/" + totalParts;
    }
}
