using UnityEngine;

public class SwordHitbox : MonoBehaviour {

    private LayerMask enemyLayer;
    public int damage;

    private void Awake() {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.layer == enemyLayer.value) {
            other.GetComponent<Enemy>().OnHit(damage);
        }
    }
}
