using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float smoothing;
    [SerializeField] public Vector2 maxPosition;
    [SerializeField] public Vector2 minPosition;

    private void MoveCameraTowardsTarget() {
        if (transform.position != target.position) {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            Vector3 desiredPosition = Vector3.Lerp(transform.position, targetPosition,smoothing);
            transform.position = desiredPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCameraTowardsTarget();
    }
}
