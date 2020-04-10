using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogMonster : TestEnemy {

    //Variables
    [SerializeField] private Rigidbody2D logRb;
    [SerializeField] public Animator animator;
    [SerializeField] public bool targetInRange;
    [SerializeField] public bool idleWaiting = false;

    //Methods
    public void CheckAggroDistance() {
        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if ((distanceToTarget <= aggroRadius) && (distanceToTarget >= attackRadius)) {
            targetInRange = true;
            if (currentState == EnemyState.asleep) {
                StartCoroutine(WakeUpCo());
            }
            else if (currentState == EnemyState.idle || currentState == EnemyState.walk) {
                followPlayer();
            }
        }
        else if (distanceToTarget > aggroRadius) {
            targetInRange = false;
            switch (currentState) {
                case EnemyState.walk: StartCoroutine(GoIdleCo()); break;
                case EnemyState.idle: StartIdleDuration(); break;
            }
        }
    }

    public void followPlayer() {
        //Debug.Log("Following Player");
        currentState = EnemyState.walk;
        animator.SetBool("Walk", true);
        Vector3 desiredPosition = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.fixedDeltaTime);
        logRb.MovePosition(desiredPosition);
    }

    public void StartIdleDuration() {
            StartCoroutine(IdleDurationCo());
    }

    public void checkIdleState() {
        if(currentState != EnemyState.idle){
            idleWaiting = false;
        } else if(currentState == EnemyState.idle && idleWaiting == false) {
            StartCoroutine(LayDownCo());
        } else if(currentState == EnemyState.idle) {
            idleWaiting = true;
        }
    }

    //Coroutines
    private IEnumerator WakeUpCo() {
        Debug.Log("Player in Range");
        currentState = EnemyState.wakeUp;
        animator.SetTrigger("Wake Up");
        yield return new WaitForSeconds(.41f);

        currentState = EnemyState.idle;
        animator.SetTrigger("Idle");
    }

    private IEnumerator GoIdleCo() {
        Debug.Log("Going idle");
        currentState = EnemyState.idle;
        animator.SetBool("Walk", false);
        yield return new WaitForSeconds(.1f);
    }

    private IEnumerator IdleDurationCo() {
        yield return new WaitForSeconds(3f);
    }

    private IEnumerator LayDownCo() {

        Debug.Log("Going to Sleep");
        currentState = EnemyState.layDown;
        animator.SetTrigger("LayDown");
        yield return new WaitForSeconds(.5f);
        currentState = EnemyState.asleep;
        animator.SetTrigger("Sleep");

    }

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        logRb = GetComponent<Rigidbody2D>();
        currentState = EnemyState.asleep;
    }

    // Update is called once per frame
    void Update() {
        CheckAggroDistance();
        checkIdleState();
    }
}
