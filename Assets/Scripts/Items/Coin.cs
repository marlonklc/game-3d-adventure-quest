using System;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    public GameObject coinCollectPrefab;
    
    public AudioClip collectSfx;
    
    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            // TODO: ver onde colocar o audio, se no coin ou no GameManager
            //AudioManager.Instance.PlaySFX(collectSfx);
            GameObject coinCollect = Instantiate(coinCollectPrefab, transform.position, Quaternion.identity);
            Destroy(coinCollect, 2f);
            
            GameManager.Instance.CoinKept();
            
            Destroy(gameObject);
        }
    }
}
