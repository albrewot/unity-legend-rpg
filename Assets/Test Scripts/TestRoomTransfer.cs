using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestRoomTransfer : MonoBehaviour
{
    //Global Variables
    //Camera
    private TestCamera testCamera;
    [SerializeField] public Vector2 cameraChange;
    [SerializeField] public Vector3 playerChange;
    //Stage Name
    [SerializeField] public bool hasName;
    [SerializeField] public string stageNameValue;
    [SerializeField] public TextMeshProUGUI stageNameComponent;
    [SerializeField] public GameObject stageNameObject;

    //Methods
    public void ShowStageName() {
        stageNameObject.SetActive(false);
        if (hasName && !stageNameObject.activeInHierarchy) {
            StartCoroutine(StageNameCo());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        testCamera = Camera.main.GetComponent<TestCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            testCamera.cameraMin += cameraChange;
            testCamera.cameraMax += cameraChange;
            collision.transform.position += playerChange;
            ShowStageName();
        }
    }

    //Co-routines
    public IEnumerator StageNameCo() {
        stageNameComponent.text = stageNameValue;
        stageNameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        stageNameObject.SetActive(false);
    }
}
