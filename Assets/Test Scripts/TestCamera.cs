using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    //Global Variables
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing;
    [SerializeField] public Vector2 cameraMin;
    [SerializeField] public Vector2 cameraMax;

    public void MakeCameraFollowTarget() {
        if(transform.position != target.position) {
            Vector3 offsetTargetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            offsetTargetPosition.x = Mathf.Clamp(offsetTargetPosition.x, cameraMin.x, cameraMax.x); 
            offsetTargetPosition.y = Mathf.Clamp(offsetTargetPosition.y, cameraMin.y, cameraMax.y); 
            transform.position = Vector3.Lerp(transform.position, offsetTargetPosition, smoothing);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        MakeCameraFollowTarget();
    }
}
