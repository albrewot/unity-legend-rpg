using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMonster : Enemy
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform homePosition;
    [SerializeField] private float aggroRadius;
    [SerializeField] private float attackRadius;

    public void CheckDistance() {
        if((Vector3.Distance(target.position, transform.position) <= aggroRadius) && (Vector3.Distance(target.position, transform.position) >= attackRadius)) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.fixedDeltaTime);
        } else if((Vector3.Distance(target.position, transform.position) <= aggroRadius)) {
            transform.position = Vector3.MoveTowards(transform.position, homePosition.position, movementSpeed * Time.fixedDeltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        homePosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
}
