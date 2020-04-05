using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    //Global Variables
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Animator animator;

    public void CaptureInputs() {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        CaptureInputs();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAnimationsAndMove();
    }
}
