using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TestState {
    walk,
    attack,
    interact
}

public class TestMovement : MonoBehaviour {
    //Global Variables
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Animator animator;
    [SerializeField] public TestState currentState;


    //Methods
    public void CaptureInputs() {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void CaptureAttackInput() {
        if (Input.GetKeyDown(KeyCode.Space) && currentState != TestState.attack) {
            StartCoroutine(AttackCo());
        }
        else if(currentState == TestState.walk) {
            UpdateAnimationsAndMove();
        }
    }

    public void UpdateAnimationsAndMove() {
        if (movement != Vector3.zero) {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            ApplyMovement();
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void ApplyMovement() {
        playerRb.MovePosition(transform.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }

    //Coroutines

    public IEnumerator AttackCo() {
        animator.SetTrigger("Attack");
        currentState = TestState.attack;
        yield return new WaitForSeconds(.5f);
        currentState = TestState.walk;
    }

    // Start is called before the first frame update
    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentState = TestState.walk;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
    }

    private void Update() {
        CaptureInputs();
        CaptureAttackInput();
    }

    // Update is called once per frame
    void FixedUpdate() {
    }
}
