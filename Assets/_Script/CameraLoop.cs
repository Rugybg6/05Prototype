using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLoop : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    private float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        xRotation -= mouseY * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        float mouseX = Input.GetAxis("Mouse X");
        playerBody.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);
    }
}
