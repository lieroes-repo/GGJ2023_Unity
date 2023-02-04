using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SetSunEventActive(bool isActive)
    //{
    //    Debug.Log("Sun is " + isActive);
    //    for (int plant = 0; plant < plants.Length; plant++)
    //    {
    //        plants[plant].PlantSunEventActivity(isActive);
    //    }
    //    gameObject.SetActive(isActive);
        
    //}

    //public void ObstructSun(bool isObstructed)
    //{
    //    for (int plant = 0; plant < plants.Length; plant++)
    //    {
    //        plants[plant].isLit = !isObstructed;
    //        plants[plant].PlantSunEventActivity(!isObstructed);
    //    }
    //}
}
