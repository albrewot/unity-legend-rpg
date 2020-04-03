using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D playerRigidBody;
    public Animator animator;
    private Vector3 movement;

    public void CaptureMovementInputs() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void TriggerWalkingAnimations() {
        if (movement != Vector3.zero) {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void ApplyMovement() {
        playerRigidBody.MovePosition(transform.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update() {
        CaptureMovementInputs();
    }

    private void FixedUpdate() {
        ApplyMovement();
        TriggerWalkingAnimations();
    }
}
