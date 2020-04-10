using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    asleep,
    wakeUp,
    layDown,
    idle,
    walk
}

public class TestEnemy : MonoBehaviour
{
    [SerializeField] public string enemyName;
    [SerializeField] public int health;
    [SerializeField] public int baseAttack;
    [SerializeField] public float aggroRadius;
    [SerializeField] public float attackRadius;
    [SerializeField] public float movementSpeed;
    [SerializeField] public Transform target;
    [SerializeField] public Transform homePosition;
    [SerializeField] public EnemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
