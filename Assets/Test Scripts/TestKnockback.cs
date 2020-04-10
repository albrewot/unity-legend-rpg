using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKnockback : MonoBehaviour
{
    [SerializeField] float thrustForce;
    [SerializeField] float KnockTime;

    //Methods
    public void ApplyKnockback(GameObject enemy) {
        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        if(enemyRb != null) {
            Vector2 difference = enemyRb.transform.position - transform.position;
            difference = difference.normalized * thrustForce;
            enemyRb.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockCo(enemyRb));
        }
    }    


    //Coroutines
    private IEnumerator KnockCo(Rigidbody2D enemyRb) {
        if(enemyRb != null) {
            yield return new WaitForSeconds(KnockTime);
            enemyRb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            ApplyKnockback(collision.gameObject);
        }
    }
}
