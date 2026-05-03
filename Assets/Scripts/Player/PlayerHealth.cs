using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private static int MAX_LIFE = 100; // TODO: refatorar quando a vida maxima for aumentando
    
    private int life = MAX_LIFE;
    private bool isDead;

    public Image[] hearts;
    public Sprite heartFull;
    public Sprite heartEmpty;

    public GameObject gameOverPanel;
    public GameObject playerHitFx;
    
    public AudioClip takeDamageSfx;

    private Player player;

    private static readonly int ANIMATOR_DIE = Animator.StringToHash("die");
    private static readonly int ANIMATOR_HIT = Animator.StringToHash("hit");

    private void Awake() {
        player = GetComponent<Player>();
    }

    public void RecoverHealth(int amount) {
        life += amount;

        if (life > MAX_LIFE) life = MAX_LIFE;

        UpdateHearts();
    }
    
    public void TakeDamage(int damage) {
        AudioManager.Instance.PlaySFX(takeDamageSfx);
        player.ShakeCamera();
        GameObject hitEffect = Instantiate(playerHitFx, transform.position + new Vector3(0, 1f, 0), transform.rotation);
        Destroy(hitEffect, 2f);

        life -= damage;
        
        UpdateHearts();
        
        if (life <= 0) {
            Death();
            return;
        }

        player.Animator.SetTrigger(ANIMATOR_HIT);
        StartCoroutine(DelayedHit());
    }

    private void UpdateHearts() {
        int totalHearts = hearts.Length;
        int healthPerHeart = MAX_LIFE / totalHearts;
        int fullHearts = Mathf.CeilToInt((float)life / healthPerHeart);

        for (int i = 0; i < totalHearts; i++) {
            Sprite spriteHeart = i < fullHearts ? heartFull : heartEmpty;
            
            hearts[i].sprite = spriteHeart;
        }
    }

    void Death() {
        isDead = true;
        player.Animator.SetTrigger(ANIMATOR_DIE);

        player.isPaused = true;

        StartCoroutine(DelayedGameOver());
    }

    IEnumerator DelayedGameOver() {
        yield return new WaitForSeconds(1.5f);
        gameOverPanel.SetActive(true);
    }

    IEnumerator DelayedHit() {
        player.isPaused = true;
        yield return new WaitForSeconds(0.5f);
        player.isPaused = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene("main_menu");
        
        Destroy(gameObject);
    }

    public bool isPlayerDead() {
      return isDead;
    }
}
