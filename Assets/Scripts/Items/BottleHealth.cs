using UnityEngine;

public class BottleHealth : MonoBehaviour {
    
    public GameObject bottleCollectPrefab;
    public ItemData itemData;

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            GameObject prefab = Instantiate(bottleCollectPrefab, transform.position, Quaternion.identity);
            Destroy(prefab, 2f);
            
            Inventory.Instance.AddItem(itemData);
            
            Destroy(gameObject);
        }
    }
}
