using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int life;

    public Animator animator;
    public Renderer enemyRenderer;
    public GameObject hitFx;
    public Collider collider;
    public Rigidbody rigidbody;

    public AudioClip hitSfx;

    public virtual void Move() {}

    public virtual void Attack() {}

    public void OnHit(int damage) {
        AudioManager.Instance.PlaySFX(hitSfx);

        life -= damage;

        if (life <= 0) {
            Death();
            Destroy(gameObject, 2f);
            return;
        }
        
        animator.SetTrigger("hit"); // TODO: refatorar para enviar hash

        Player.Instance.ShakeCamera();

        StartCoroutine(HitFlash());

        GameObject hitEffect = Instantiate(hitFx, transform.position + new Vector3(0, 1f, 0), transform.rotation);

        Destroy(hitEffect, 2f);
    }   

    IEnumerator HitFlash() {
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        enemyRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.3f);
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        enemyRenderer.material.color = Color.white;
    }

    public virtual void Death() {}
}
