using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCustomizationRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public bool rotateRight;
    public float rotateSpeed;

    private bool isHolding;
    private float direction;

    private void Update() {
        if (isHolding) {
            direction = rotateRight ? -1f : 1f;
            
            Player.Instance.transform.Rotate(0, direction * rotateSpeed * Time.deltaTime, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        isHolding = true;
    }
    
    public void OnPointerUp(PointerEventData eventData) {
        isHolding = false;
    }
}
