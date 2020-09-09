using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100;
    public float viewClamping = 40f;


    private float xRotation = 0f;
    private float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xRotation -=  Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -viewClamping, viewClamping);
        yRotation = Mathf.Clamp(yRotation, -viewClamping, viewClamping);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
