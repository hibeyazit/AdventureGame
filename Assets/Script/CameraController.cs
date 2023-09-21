using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensivity = 10;
    public Transform target;
    public float dstFromTarget=5;
    public Vector2 pitchMinMax = new Vector2(-40,80);

    public float rotationSmoothTime=1.2f;
    Vector3 rotationSmoothTimeVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;


    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X")*mouseSensivity;
        pitch -= Input.GetAxis("Mouse Y")*mouseSensivity;
        pitch = Mathf.Clamp(pitch,pitchMinMax.x,pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch,yaw),ref rotationSmoothTimeVelocity,rotationSmoothTime);

        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * dstFromTarget;


         
    }
}
