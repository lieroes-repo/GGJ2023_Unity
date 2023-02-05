using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.0f, 45.0f)] public float CameraRotateLimit = 20.0f;

    [Range(0.0001f, 0.01f)] public float mouseSensitivity = 0.5f;

    private float cameraRotY = 0f;

    private Vector3 mouseScreenPos;
    public Vector3 mouseWorldPos { get; set; }
    public GameObject wateringCan;

    private float sunPosX;
    private bool mouseDown = false;

    private bool fToggle = false;

    // Start is called before the first frame update
    void Start()
    {
        sunPosX = FindObjectOfType<Sun>().gameObject.transform.position.x;
        wateringCan = new GameObject();
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

        if (Input.GetKeyDown("F"))
        {
            if (!fToggle)
            {
                fToggle = true;
            }
            else
            {
                fToggle = false;
            }
        }

        while (fToggle = true)
        {
            // water plants
            //Mouse movement
            mouseScreenPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
            if (Physics.Raycast(ray, out RaycastHit hitData))
            {
                //mouseWorldPos now contains the hit location
                mouseWorldPos = hitData.point;
                Vector3 newPos = new Vector3(mouseWorldPos.x, hitData.transform.position.y,
                    hitData.transform.position.z);
                newPos.x = Mathf.Clamp(newPos.x, -sunPosX, sunPosX - 1);
                wateringCan.transform.position = newPos;

                if (Input.GetMouseButton(0))
                {
                    mouseDown = true;
                    if (hitData.collider.tag == "Clickable")
                    {

                        // Vector3 newPos = new Vector3(mouseWorldPos.x, hitData.transform.position.y,
                        //     hitData.transform.position.z);
                        // newPos.x = Mathf.Clamp(newPos.x, -sunPosX, sunPosX - 1);
                        // hitData.transform.localPosition = newPos;

                    }

                }
            }
        }
    }
}
