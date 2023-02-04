using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : MonoBehaviour
{
    private Sun sun;

    private Cloud[] clouds;

    
    bool enableSun = true;
    // Start is called before the first frame update
    void Start()
    {
        sun = FindObjectOfType<Sun>();
        clouds = FindObjectsOfType<Cloud>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSun)
        {
            sun.SetSunEventActive(true);
            enableSun = false;
        }
    }
}
