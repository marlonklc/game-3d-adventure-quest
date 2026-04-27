using UnityEngine;

public class EnemyAlert : MonoBehaviour {

    public Transform target;
    public float yOffset;

    private void Update() {
        if (target != null) {
            Vector3 targetPosition = target.position + Vector3.up * yOffset;
            transform.position = targetPosition;
            transform.forward = Camera.main.transform.forward;
        }
    }
}
