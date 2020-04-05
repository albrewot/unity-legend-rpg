using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public PlayerState currentState;
    public float speed;
    public Rigidbody2D playerRigidBody;
    public Animator animator;
    private Vector3 movement;

    public void CaptureMovementInputs() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void CaptureAttackInput() {
        if(Input.GetKeyDown(KeyCode.Space) && currentState != PlayerState.attack) {
            StartCoroutine(AttackCo());
        } else if(currentState == PlayerState.walk) {
            TriggerWalkingAnimations();
        }
    }

    public void TriggerWalkingAnimations() {
        if (movement != Vector3.zero) {
            ApplyMovement();
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void ApplyMovement() {
        playerRigidBody.MovePosition(transform.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    // Use this for initialization
    private void Start() {
        currentState = PlayerState.walk;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", -1);
    }

    // Update is called once per frame
    private void Update() {
        CaptureMovementInputs();
        CaptureAttackInput();
    }

    private IEnumerator AttackCo() {
        animator.SetTrigger("Attack");
        currentState = PlayerState.attack;
        yield return new WaitForSeconds(0.5f);
        currentState = PlayerState.walk;
    }
}
