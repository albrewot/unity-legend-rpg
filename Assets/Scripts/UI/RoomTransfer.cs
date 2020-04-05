using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomTransfer : MonoBehaviour
{
    //Camera Variables
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement gameCamera;

    //Stage Name Variables
    public bool needText;
    public string stageName;
    public GameObject tmpText;
    public TextMeshProUGUI stageText;

    //Methods
    public void HandleStageText() {
        if (needText) {
            StartCoroutine(stageNameCo());
        }
    }

    private IEnumerator stageNameCo() {
        tmpText.SetActive(true);
        stageText.text = stageName;

        yield return new WaitForSeconds(4f);

        tmpText.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(stageName + " Triggered");
        if (collision.CompareTag("Player")) {
            gameCamera.minPosition += cameraChange;
            gameCamera.maxPosition += cameraChange;
            collision.transform.position += playerChange;
            HandleStageText();
        }
    }
}
