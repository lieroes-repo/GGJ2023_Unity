using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{

    private Vector3 pz;
    private Vector3 StartPos;

    public float modifier;

    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
        transform.position = new Vector3(StartPos.x + (pz.x * modifier), StartPos.y + (pz.y * modifier), 0);
    }

}

