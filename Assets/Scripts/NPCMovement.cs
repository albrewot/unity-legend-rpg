using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D npcRigidBody;
    public Animator animator;
    private Vector3 movement;

    public void CaptureInputs() {
        movement = Vector3.zero;
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

    public void MoveNPC() {
        npcRigidBody.MovePosition(transform.position + movement.normalized * speed * Time.fixedDeltaTime);
    }


    // Update is called once per frame
    void Update()
    {
        CaptureInputs();
    }

    private void FixedUpdate() {
        MoveNPC();
        TriggerWalkingAnimations();
    }
}
