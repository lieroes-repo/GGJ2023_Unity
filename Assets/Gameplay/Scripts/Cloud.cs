using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "GamePlant")
        {
            collision.gameObject.GetComponent<GrowingPlant>().PlantInCloudShade(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "GamePlant")
        {
            collision.gameObject.GetComponent<GrowingPlant>().PlantInCloudShade(false);
        }
    }
}
