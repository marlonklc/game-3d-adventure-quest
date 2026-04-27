using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject {
    
    [System.Serializable]
    public enum ItemEffect {
        health,
        speed,
        damage
    }

    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    
    public ItemEffect itemEffect;
    public int amount;

    public void Apply() {

        // TODO: usar OOP para melhorar comportamento dinamico
        switch (itemEffect) {

            case ItemEffect.health: {
                Player.Instance.playerHealth.RecoverHealth(amount);
            }
            break;
            
            case ItemEffect.speed: {
                
            }
            break;
            
            case ItemEffect.damage: {
                
            }
            break;
        }
    }
}
