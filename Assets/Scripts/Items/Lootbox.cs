using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lootbox : MonoBehaviour {

    public GameObject idleLootbox;
    public GameObject destroyLootbox;
    public Animator animator;
    public Collider collider;
    public Transform spawnPoint;
    
    public GameObject[] loots;

    public AudioClip destroySfx;
    public AudioClip newItemSfx;
    
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.GetComponent<SwordHitbox>()) {
            Destroy();
            GenerateLoot();
        }
    }

    private void GenerateLoot() {
        Instantiate(loots[Random.Range(0, loots.Length)], spawnPoint.position, Quaternion.identity);
    }

    private void Destroy() {
        AudioManager.Instance.PlaySFX(destroySfx);
        AudioManager.Instance.PlaySFX(newItemSfx);
        
        idleLootbox.SetActive(false);
        destroyLootbox.SetActive(true);
        collider.enabled = false;
        
        animator.Play("Bang");
        
        Destroy(gameObject, 2f);
    }
}
