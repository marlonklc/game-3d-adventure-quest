using System;
using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCrab : Enemy {

    // detection
    bool isPlayerVisible;
    public float detectionRadius;
    public float rotationSpeed;

    // attack
    public float attackRange;
    public float attackCooldown;
    private float lastAttackTime;

    // others
    public float moveSpeed;
    public int damage;
    public GameObject canvaAlert;
    private float distanceToPlayer;
    public EnemyDamageHitbox clawHitbox;

    private static readonly int ANIMATOR_DIE = Animator.StringToHash("die");
    private static readonly int ANIMATOR_SPEED = Animator.StringToHash("speed");
    private static readonly int ANIMATOR_ATTACK = Animator.StringToHash("attack");

    private void Start() {
        clawHitbox.damage = damage;
    }

    private void Update() {
        distanceToPlayer = Vector3.Distance(transform.position, Player.Instance.transform.position);

        // TODO: melhorar logica, dá pra simplificar bastante
        if (!isPlayerVisible) {
            if (distanceToPlayer <= detectionRadius) {
                isPlayerVisible = true;
                GameObject alert = Instantiate(canvaAlert);
                alert.GetComponent<EnemyAlert>().target = transform;
                Destroy(alert, 1.5f);
            }
            
        } else {
            if (distanceToPlayer > detectionRadius) {
                isPlayerVisible = false;
                animator.SetFloat(ANIMATOR_SPEED, 0);
                return;
            }

            RotationTowardsPlayer();

            if (distanceToPlayer > attackRange) {
                animator.SetFloat(ANIMATOR_SPEED, 1);

                Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
                direction.y = 0;
                rigidbody.MovePosition(rigidbody.position + direction * moveSpeed * Time.fixedDeltaTime);
            } else {
                animator.SetFloat(ANIMATOR_SPEED, 0);
            }

            if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown && !Player.Instance.isDead()) {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    IEnumerator DelayedEnemyAlert() {
        yield return new WaitForSeconds(1f);
    }

    public void Attack() {
        animator.SetTrigger(ANIMATOR_ATTACK);
    }

    void RotationTowardsPlayer() {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        direction.y = 0f;

        if (direction != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public override void Death() {
        animator.SetTrigger(ANIMATOR_DIE);
        enabled = false;
        collider.enabled = false;
        rigidbody.useGravity = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
