using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {
    //Variables

    //Methods
    public void ApplyKnockback(Rigidbody2D enemyRb) {
        Vector2 difference = enemyRb.transform.position - transform.position;

    }

    //Unity Life-Cycle
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            if(collision.gameObject != null) {
                Rigidbody2D enemyRb = collision.GetComponent<Rigidbody2D>();
                ApplyKnockback(enemyRb);
            }
        }
    }
}
