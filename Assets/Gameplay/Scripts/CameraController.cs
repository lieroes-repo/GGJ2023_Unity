using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.0f, 45.0f)]
    public float CameraRotateLimit = 20.0f;

    [Range(0.0001f, 0.01f)]
    public float mouseSensitivity = 0.5f;

    private float cameraRotY = 0f;

    private Vector3 mouseScreenPos;
    public Vector3 mouseWorldPos { get; set; }

    private float sunPosX;

    // Start is called before the first frame update
    void Start()
    {
        sunPosX = FindObjectOfType<Sun>().gameObject.transform.position.x;
    }

    private void FixedUpdate()
    {
        //Camera movement
        // float mouseX = (Input.GetAxis("Mouse X") - (Screen.width / 2))/* * mouseSensitivity * Time.deltaTime*/;
        float mouseX = (Input.mousePosition.x - (Screen.width / 2)) * mouseSensitivity;
        cameraRotY = mouseX;
        cameraRotY = Mathf.Clamp(cameraRotY, -CameraRotateLimit, CameraRotateLimit);

        transform.localRotation = Quaternion.Euler(gameObject.transform.localEulerAngles.x, cameraRotY,
            gameObject.transform.localEulerAngles.z);
    }
}
