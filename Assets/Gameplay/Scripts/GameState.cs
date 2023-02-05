using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK;

public class GameState : MonoBehaviour
{
    private Sun sun;

    private Cloud[] clouds;

    private int spawnedPlantsID = 0;

    public AK.Wwise.Event bellEvent;
    public GrowingPlant[] allPlants;

    // Start is called before the first frame update
    void Start()
    {
        sun = FindObjectOfType<Sun>();

        clouds = FindObjectsOfType<Cloud>();

        //InvokeRepeating("TriggerEvent", 8, 8);

        for (int i = 0; i < allPlants.Length; i++) 
        {
            allPlants[i].enabled = false;
        }
        //SpawnPlant();
    }
    public void BeginPlay()
    {
        InvokeRepeating("TriggerEvent", 3, 8);
        SpawnPlant();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPlant()
    {
        
        if (spawnedPlantsID < allPlants.Length)
        {
            Debug.LogWarning("Spawned Plant #" + spawnedPlantsID);
            allPlants[spawnedPlantsID].enabled = true;
            allPlants[spawnedPlantsID].SetPlantSectionState(0, SECTION_STATE.IDLE);
            spawnedPlantsID++;
        }
        else
        {
            bellEvent.Post(gameObject);
        }
        
    }

    public void ActivateSun()
    {
        sun.gameObject.SetActive(true);
        sun.GetComponent<SphereCollider>().enabled = true;
        sun.GetComponent<Light>().enabled = true;
        for (int i = 0; i < spawnedPlantsID; i++)  
        {
            allPlants[i].PlantSunEventActivity(true);
        }
        Invoke("DeActivateSun", 5.0f);
    }
    public void DeActivateSun()
    {
        sun.GetComponent<SphereCollider>().enabled = false;
        sun.GetComponent<Light>().enabled = false;
        for (int i = 0; i < spawnedPlantsID; i++)
        {
            allPlants[i].PlantSunEventActivity(false);
        }
        CancelInvoke("DeActivateSun");
        Invoke("DelayedSunDisapearence", 1.25f);
        
    }

    public void DelayedSunDisapearence()
    {
        Debug.LogWarning("Sun despawn time!");
        sun.gameObject.SetActive(false);
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
                //sun event
                ActivateSun();
                break;

            //case 2:
            //    //water event
            //    break;
        }
    }

    
}
