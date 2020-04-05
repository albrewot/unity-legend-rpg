using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBreakable() {
        animator.SetTrigger("Break");
        //RemoveGameObject();
        StartCoroutine(BreakCo());
    }

    private void RemoveGameObject() {
        Destroy(gameObject);
    }

    private IEnumerator BreakCo() {
        yield return new WaitForSeconds(0.41f);
        Destroy(gameObject);
    }
}
