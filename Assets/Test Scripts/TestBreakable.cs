using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBreakable : MonoBehaviour
{
    [SerializeField] private Animator animator;

    //Methods
    public void BreakObject() {
        StartCoroutine(BreakCo());
    }

    //Coroutines
    private IEnumerator BreakCo() {
        animator.SetTrigger("Break");
        yield return new WaitForSeconds(0.41f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
