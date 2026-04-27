using System;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    public GameObject coinCollectPrefab;
    
    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            GameObject coinCollect = Instantiate(coinCollectPrefab, transform.position, Quaternion.identity);
            Destroy(coinCollect, 2f);
            
            GameManager.Instance.CoinKept();
            
            Destroy(gameObject);
        }
    }
}
