using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestSign : MonoBehaviour {
    //Global Variables
    [SerializeField] public bool playerInRange;
    //Interact Variables
    [SerializeField] public string interactNoticeText;
    [SerializeField] public GameObject interactNoticeObject;
    [SerializeField] public TextMeshProUGUI interactNoticeUI;
    //Content Variables
    [SerializeField] public GameObject dialogBoxObject;
    [SerializeField] public string dialogBoxText;
    [SerializeField] public TextMeshProUGUI dialogBoxUI;

    //Methods
    public void CaptureInteractInput() {

        if ((playerInRange && Input.GetKeyDown(KeyCode.F))) {
            Debug.Log("Pressed");
            if (!dialogBoxObject.activeInHierarchy) {
                dialogBoxObject.SetActive(true);
                interactNoticeObject.SetActive(false);
            }
            else {
                interactNoticeObject.SetActive(true);
                dialogBoxObject.SetActive(false);
            }
        }
    }

    private void SetTextInSign() {
        interactNoticeUI.text = interactNoticeText;
        dialogBoxUI.text = dialogBoxText;
    }


    //Coroutines

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        CaptureInteractInput();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        SetTextInSign();
        if (collision.CompareTag("Player")) {
            playerInRange = true;
            interactNoticeObject.SetActive(true);
            Debug.Log(interactNoticeUI.text);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerInRange = false;
            interactNoticeObject.SetActive(false);
            dialogBoxObject.SetActive(false);
        }
    }


}
