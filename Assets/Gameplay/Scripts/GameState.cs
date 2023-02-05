using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameState : MonoBehaviour
{
    private Sun sun;

    private Cloud[] clouds;

    private int spawnedPlantsID = 0;

    public GrowingPlant[] allPlants;

    // Start is called before the first frame update
    void Start()
    {
        sun = FindObjectOfType<Sun>();

        clouds = FindObjectsOfType<Cloud>();

        InvokeRepeating("SpawnPlant", 5, 15);
        InvokeRepeating("TriggerEvent", 7, 5);

        for (int i = 0; i < allPlants.Length; i++) 
        {
            allPlants[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPlant()
    {
        
        if (spawnedPlantsID < allPlants.Length)
        {
            Debug.LogWarning("Spawned Plant #" + spawnedPlantsID);
            allPlants[spawnedPlantsID].enabled = true;
            allPlants[spawnedPlantsID].SetPlantSectionState(0, SECTION_STATE.IDLE);
            spawnedPlantsID++;
        }
        
    }

    public void ActivateSun()
    {
        sun.gameObject.SetActive(true);
        for (int i = 0; i < spawnedPlantsID; i++)  
        {
            allPlants[i].PlantSunEventActivity(true);
        }
        Invoke("DeActivateSun", 5.0f);
    }
    public void DeActivateSun()
    {
        sun.gameObject.SetActive(false);
        for (int i = 0; i < spawnedPlantsID; i++)
        {
            allPlants[i].PlantSunEventActivity(false);
        }
        CancelInvoke("DeActivateSun");
    }

    void TriggerEvent()
    {
        int eventToTrigger = Random.Range(0, 2);//0 or 1

        Debug.LogWarning("Event #" + eventToTrigger);
        switch (eventToTrigger)
        {
            case 0:
                //sun event
                ActivateSun();
                break;
            case 1:
                
                break;

            //case 2:
            //    //water event
            //    break;
        }
    }

    
}
