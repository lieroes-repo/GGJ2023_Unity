using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SECTION_STATE
{
    NOTSTARTED,
    IDLE,
    GROWING,
    GROWN,
    FAILED
}

public class GrowingPlant : MonoBehaviour
{
    

    struct PlantSection
    {
        public MeshRenderer renderer;
        public SECTION_STATE state;
        //Total Timer for the stage growth (each stage spends X time to progress/fail)
        public float timeForGrowthStage;
    }

    public MeshRenderer[] sectionRenderers;

    //The amount of time each plant stage has to grow before it fails
    [Range(1.0f, 20.0f)]
    private float GrowthEventTimer = 4.9f;

    private PlantSection[] plantSections;
    //if the plant has been watered recently
    private bool isMoist = false;
    //if the plant is in the sun (sun is bad for it and == true, shade is good and == false)
    public bool isLit { get; set; }





    void Awake()
    {
        isLit = false;
        //init the plant sections
        plantSections = new PlantSection[sectionRenderers.Length];
        for (int i = 0; i < sectionRenderers.Length; i++)
        {
            plantSections[i].renderer = sectionRenderers[i];
            plantSections[i].renderer.enabled = false;
            plantSections[i].state = SECTION_STATE.NOTSTARTED;
            plantSections[i].timeForGrowthStage = GrowthEventTimer;
        }
    }

 
    void Update()
    {
        for (int i = 0; i < plantSections.Length; i++)
        {
            //if this section event is active AKA growing
            if(plantSections[i].state == SECTION_STATE.GROWING)
            {
                plantSections[i].timeForGrowthStage -= Time.deltaTime;
                //if plant is in good condition
                if (isMoist || !isLit)
                {
                    //event success!
                    SetPlantSectionState(i, SECTION_STATE.GROWN);
                }
                else if (plantSections[i].timeForGrowthStage <= 0.0f)
                {
                    //event fail
                    SetPlantSectionState(i, SECTION_STATE.FAILED);
                }
            }
        }

    }

    public void SetPlantSectionState(int sectionID, SECTION_STATE newState)
    {
        
        if(sectionID < plantSections.Length)
        {
            Debug.Log(gameObject.name + " Section " + sectionID.ToString() + " will be " + newState.ToString());

            switch (newState)
            {
                case SECTION_STATE.NOTSTARTED:
                    plantSections[sectionID].renderer.enabled = false;
                    plantSections[sectionID].state = newState;
                    break;
                case SECTION_STATE.IDLE:
                    plantSections[sectionID].renderer.enabled = false;
                    plantSections[sectionID].state = newState;
                    break;
                case SECTION_STATE.GROWING:
                    plantSections[sectionID].renderer.enabled = false;
                    plantSections[sectionID].state = newState;
                    plantSections[sectionID].timeForGrowthStage = GrowthEventTimer;
                    break;
                case SECTION_STATE.GROWN:
                    plantSections[sectionID].renderer.enabled = true;
                    plantSections[sectionID].timeForGrowthStage = GrowthEventTimer;
                    //start next section
                    if (plantSections[sectionID].state == SECTION_STATE.GROWING)
                    {
                        if ((sectionID + 1) < plantSections.Length)
                        {
                            //start next sections growth (from not started to idle)
                            SetPlantSectionState(sectionID + 1, SECTION_STATE.IDLE);
                        }
                        else
                        {
                            //plant is complete!
                            FindObjectOfType<GameState>().SpawnPlant();

                        }
                    }
                    plantSections[sectionID].state = newState;

                    break;
                case SECTION_STATE.FAILED:
                    plantSections[sectionID].renderer.enabled = false;
                    //start next section
                    if (plantSections[sectionID].state == SECTION_STATE.GROWING)
                    {
                        if ((sectionID - 1) >= 0)
                        {
                            //revert to previous sections growth (from not started to idle)
                            SetPlantSectionState(sectionID - 1, SECTION_STATE.IDLE);
                        }
                        else
                        {
                            SetPlantSectionState(sectionID, SECTION_STATE.IDLE);

                        }
                    }
                    plantSections[sectionID].state = newState;

                    break;
            }
        }
        
    }

    public void PlantSunEventActivity(bool isActive)
    {
        //if sun is active, plant is LIT (aka not unlit)
        isLit = isActive;

        //if sun event started, go from idle to growing (goal of player is to un-lit plant while its growing)
        if (isLit)
        {
            if (plantSections[0].state == SECTION_STATE.NOTSTARTED || plantSections[0].state == SECTION_STATE.FAILED)
                SetPlantSectionState(0, SECTION_STATE.IDLE);
            for (int i = 0; i < plantSections.Length; i++)
            {
                //if this section event is active AKA growing
                if (plantSections[i].state == SECTION_STATE.IDLE || plantSections[i].state == SECTION_STATE.GROWING)
                {
                    SetPlantSectionState(i, SECTION_STATE.GROWING);
                }
                
            }
        }
        
    }

    //public void PlantInCloudShade(bool inShade)
    //{
    //    Sun sunObj = GameObject.FindObjectOfType<Sun>();
    //    if (!sunObj.gameObject.activeSelf)
    //    {
    //        //if sun is inactive
    //        isLit = false;
    //    }
    //    else
    //    {
    //        //plant is not lit if its in the shade
    //        isLit = !inShade;
    //    }
    //    Debug.Log("cloud is lit?: " + isLit);
    //}
}
