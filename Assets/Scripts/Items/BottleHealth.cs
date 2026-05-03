using UnityEngine;

public class BottleHealth : MonoBehaviour {
    
    public GameObject bottleCollectPrefab;
    public ItemData itemData;
    
    public AudioClip collectSfx;

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            AudioManager.Instance.PlaySFX(collectSfx);
            GameObject prefab = Instantiate(bottleCollectPrefab, transform.position, Quaternion.identity);
            Destroy(prefab, 2f);
            
            Inventory.Instance.AddItem(itemData);
            
            Destroy(gameObject);
        }
    }
}
