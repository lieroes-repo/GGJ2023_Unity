using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrowingPlant : MonoBehaviour
{
    public enum SECTION_STATE
    {
        NOTSTARTED,
        IDLE,
        GROWING,
        GROWN,
        FAILED
    }

    struct PlantSection
    {
        public MeshRenderer renderer;
        public SECTION_STATE state;
        //Total Timer for the stage growth (each stage spends X time to progress/fail)
        public float timeForGrowthStage;
    }

    public MeshRenderer[] sectionRenderers;

    //The amount of time each plant stage has to grow before it fails
    [Range(1.0f, 100.0f)]
    public float GrowthEventTimer = 15.0f;

    private PlantSection[] plantSections;
    //if the plant has been watered recently
    private bool isMoist = false;
    //if the plant is in the sun (sun is bad for it and == true, shade is good and == false)
    private bool isLit = false;

    // Start is called before the first frame update
    void Start()
    {

        //init the plant sections
        plantSections = new PlantSection[sectionRenderers.Length];
        for (int i = 0; i < sectionRenderers.Length; i++)
        {
            plantSections[i].renderer = sectionRenderers[i];
            plantSections[i].renderer.enabled = false;
            plantSections[i].state = SECTION_STATE.NOTSTARTED;
            plantSections[i].timeForGrowthStage = GrowthEventTimer;
        }

        //first section starts growing as soon as plant spawns.
        if (plantSections.Length >= 1)
            plantSections[0].state = SECTION_STATE.IDLE;
    }

    // Update is called once per frame
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

    private void SetPlantSectionState(int sectionID, SECTION_STATE newState)
    {

        //if section was prev in growing state, and is going to a complete state, activate the next plant section.
        if(plantSections[sectionID].state == SECTION_STATE.GROWING)
        {
            if(newState == SECTION_STATE.GROWN || newState == SECTION_STATE.FAILED)
            {
                if((sectionID + 1) < plantSections.Length)
                {
                    //start next sections growth (from not started to idle)
                    SetPlantSectionState(sectionID + 1, SECTION_STATE.IDLE);
                }
            }
        }
        
        //the actual SET STATE
        plantSections[sectionID].state = newState;


        //TODO: add logic for going from state to state
    }

    public void PlantSunEventActivity(bool isActive)
    {
        //if sun is active, plant is LIT (aka not unlit)
        isLit = isActive;

        //if sun event started, go from idle to growing (goal of player is to un-lit plant while its growing)
        if (isLit)
        {
            for (int i = 0; i < plantSections.Length; i++)
            {
                //if this section event is active AKA growing
                if (plantSections[i].state == SECTION_STATE.IDLE)
                {
                    SetPlantSectionState(i, SECTION_STATE.GROWING);
                }
            }
        }
        
    }

    public void PlantInCloudShade(bool inShade)
    {
        Sun sunObj = GameObject.FindObjectOfType<Sun>();
        if (!sunObj.gameObject.activeSelf)
        {
            //if sun is inactive
            isLit = false;
        }
        else
        {
            //plant is not lit if its in the shade
            isLit = !inShade;
        }
    }
}
