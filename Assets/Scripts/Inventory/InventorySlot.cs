using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    
    public ItemData itemData;
    public Button button;
    public GameObject tooltipImage;
    
    // TODO: gambi para duplo clique
    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = 0.3f;
    
    private void OnEnable() {
        if (itemData == null) {
            button.gameObject.SetActive(false);
            return;
        }
        
        button.gameObject.SetActive(true);
        button.GetComponentInChildren<Image>().sprite = itemData.icon;
        tooltipImage.GetComponentInChildren<TextMeshProUGUI>().text = itemData.description;
    }

    public void ApplyItem() {
        if (itemData != null) {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= DOUBLE_CLICK_TIME) {
                Debug.Log("ApplyItem");
                itemData.Apply();
                
                button.gameObject.SetActive(false);
                tooltipImage.SetActive(false);
                itemData = null;
            }
            
            lastClickTime = Time.time;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (itemData == null) return;
        
        if (eventData.clickCount == 2) {
            Debug.Log("OnPointerClick");
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (itemData == null) return;
        
        tooltipImage.SetActive(true);
    }
    
    public void OnPointerExit(PointerEventData eventData) {
        if (itemData == null) return;
        
        tooltipImage.SetActive(false);
    }

    private void OnDisable() {
        if (itemData == null) return;
        
        tooltipImage.SetActive(false);
    }
}
