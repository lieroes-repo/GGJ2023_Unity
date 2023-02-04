using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//wwise 
using AK;
public class GameState : MonoBehaviour
{
    private Sun sun;

    private Cloud[] clouds;

    //wwise
    public AK.Wwise.Event playBackgroundEvent;
    
    bool enableSun = true;
    // Start is called before the first frame update
    void Start()
    {
        sun = FindObjectOfType<Sun>();
        clouds = FindObjectsOfType<Cloud>();
        
        // play background sound. Included this in this script cause this script is called at the start of the game
        playBackgroundEvent.Post(gameObject);
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
