using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    
    private Vector3 mouseScreenPos;
    public Vector3 mouseWorldPos { get; set; }
    
    private float sunPosX;

    public Vector3 spawnPos;

    public float smoothTime = 0.5f; 
    public float speed = 10;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = gameObject.transform.position;
        sunPosX = FindObjectOfType<Sun>().gameObject.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Mouse movement
        mouseScreenPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
        if (Physics.Raycast(ray, out RaycastHit hitData)) 
        {
            //mouseWorldPos now contains the hit location
            mouseWorldPos = hitData.point;

            if (Input.GetMouseButton(0))
            {
                if (hitData.collider.tag == "Clickable")
                {
                    Vector3 newPos = new Vector3(mouseWorldPos.x, hitData.transform.position.y, hitData.transform.position.z);
                    newPos.x = Mathf.Clamp(newPos.x, -sunPosX, sunPosX-1);
                    hitData.transform.localPosition = newPos;
                }
            }
            else
            {
                // // // Make cloud move back to original position
                //  gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, spawnPos, ref velocity, smoothTime, speed);
            }
        }
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            // // Make cloud move back to original position
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, spawnPos, ref velocity,
                smoothTime, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Sun")
        {
            FindObjectOfType<GameState>().DeActivateSun();
        }
    }

}
