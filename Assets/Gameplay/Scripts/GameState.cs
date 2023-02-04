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
        InvokeRepeating("TriggerEvent", 6, 5);

        for (int i = 0; i < allPlants.Length; i++) 
        {
            allPlants[i].gameObject.SetActive(false);
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
            allPlants[spawnedPlantsID].gameObject.SetActive(true);
            allPlants[spawnedPlantsID].SetPlantSectionState(0, SECTION_STATE.IDLE);
        }
        spawnedPlantsID++;
    }

    public void ActivateSun(bool isActive)
    {
        sun.gameObject.SetActive(isActive);
        for (int i = 0; i < allPlants.Length; i++)  
        {
            allPlants[i].PlantSunEventActivity(isActive);
        }
    }

    void TriggerEvent()
    {
        int eventToTrigger = Random.Range(0, 3);

        Debug.LogWarning("Event #" + eventToTrigger);
        switch (eventToTrigger)
        {
            case 0:
                break;
                //no event
            case 1:
                //sun event
                ActivateSun(true);
                break;

            case 2:
                //water event
                break;
        }
    }

    
}
