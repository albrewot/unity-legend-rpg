using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI interactTextUI;
    [SerializeField] private TextMeshProUGUI dialogBoxUI;
    [SerializeField] private string interactTextValue;
    [SerializeField] private string dialogBoxTextValue;
    private bool playerInRange;


    public void CaptureFInput() {
        if (Input.GetKeyDown(KeyCode.F) && playerInRange) {
            if (dialogBox.activeInHierarchy) {
                dialogBox.SetActive(false);
                interactText.SetActive(true);
            } else {
                dialogBox.SetActive(true);
                interactText.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        interactTextUI.text = interactTextValue;
        dialogBoxUI.text = dialogBoxTextValue;
    }

    // Update is called once per frame
    void Update()
    {
        CaptureFInput();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            interactText.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            interactText.SetActive(false);
            dialogBox.SetActive(false);
            playerInRange = false;
        }
    }
}
