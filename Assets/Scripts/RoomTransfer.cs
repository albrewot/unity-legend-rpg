using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement gameCamera;
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
        if (collision.CompareTag("Player")) {
            gameCamera.minPosition += cameraChange;
            gameCamera.maxPosition += cameraChange;
            collision.transform.position += playerChange;
        }
    }
}
