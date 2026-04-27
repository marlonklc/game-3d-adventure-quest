using System;
using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool isPaused;
    public float moveSpeed;
    public float rotationSpeed = 10f;

    public ParticleSystem slashFx;
    public CinemachineImpulseSource impulseSource;

    public PlayerHUD playerHUD;
    public PlayerHealth playerHealth;
    public PlayerCustomizationBody playerCustomizationBody;

    CharacterController controller;
    Animator animator;

    Vector3 inputDirection;

    bool isAttacking;
    float attackCooldown = 0.53f;

    public static Player Instance;

    private static readonly int ANIMATOR_RUNNING = Animator.StringToHash("running");
    private static readonly int ANIMATOR_SPEED = Animator.StringToHash("speed");
    private static readonly int ANIMATOR_ATTACK = Animator.StringToHash("attack");

    public Animator Animator { get => animator; set => animator = value; }

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        
        Destroy(gameObject);
    }

    void Start() {
        playerHUD = GetComponent<PlayerHUD>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (!isPaused) {
            Move();
            Attack();
            UpdateAttackState();
        }
    }

    void Move() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector3(horizontal, 0f, vertical);

        if (inputDirection != Vector3.zero && !isAttacking) {

            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            controller.Move(inputDirection * moveSpeed * Time.deltaTime);
        }

        animator.SetFloat(ANIMATOR_SPEED, inputDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift)) {
            animator.SetBool(ANIMATOR_RUNNING, true);
            moveSpeed = 6f;
        } else {
            animator.SetBool(ANIMATOR_RUNNING, false);
            moveSpeed = 4f;
        }
    }

    private void Attack() {
        if (Input.GetMouseButtonDown(0) && !isAttacking) {
            animator.SetTrigger(ANIMATOR_ATTACK);
            isAttacking = true;
            attackCooldown = 0.53f;

            slashFx.Play();
        }
    }

    private void UpdateAttackState() {
        if (isAttacking) {
            attackCooldown -= Time.deltaTime;

            if (attackCooldown <= 0f) {
                isAttacking = false;
            }
        }
    }

    public void ShakeCamera() {
        impulseSource.GenerateImpulse();
    }

    public bool isDead() {
        return playerHealth.isPlayerDead();
    }
}
    
