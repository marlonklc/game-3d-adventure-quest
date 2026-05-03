using System.Collections;
using UnityEngine;

public class TreasureChest : MonoBehaviour {
    
    public Animator animator;
    
    private float distanceToPlayer;
    private bool isPlayerNearby;
    private static float detectionRadius = 2f;
    
    private static readonly int ANIMATOR_OPEN = Animator.StringToHash("open");
    
    private void Update() {
        
        distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.transform.position);
        
        isPlayerNearby = distanceToPlayer <= detectionRadius;

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) {
            isPlayerNearby = false;
            StartCoroutine(OpenChest());
        }
    }
   
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            isPlayerNearby = true;
        }
    }

    IEnumerator OpenChest() {
        animator.SetTrigger(ANIMATOR_OPEN);
        
        yield return new WaitForSeconds(1f);
        
        GameManager.Instance.CoinKept();
        
        enabled = false;
    }
}
