using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.0f, 45.0f)]
    public float CameraRotateLimit = 20.0f;

    [Range(1.0f, 50.0f)]
    public float mouseSensitivity = 10.0f;

    private float cameraRotY = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        cameraRotY -= mouseX;
        cameraRotY = Mathf.Clamp(cameraRotY, -CameraRotateLimit, CameraRotateLimit);

        transform.localRotation = Quaternion.Euler(gameObject.transform.localEulerAngles.x, -cameraRotY, gameObject.transform.localEulerAngles.z);
    }
}