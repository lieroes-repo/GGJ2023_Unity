using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrowingPlant : MonoBehaviour
{
    public enum SECTION_STATE
    {
        MISSING,
        GROWING,
        GROWN,
        FAILED
    }

    //arrays should be considered as pairs ( render[1] is paired with state[1] )

    public MeshRenderer[] sectionRenderers;
    private SECTION_STATE[] sectionStates;

    // Start is called before the first frame update
    void Start()
    {
        //hides all sections and sets their state to "missing"
        sectionStates = new SECTION_STATE[sectionRenderers.Length];
        for (int i = 0; i < sectionRenderers.Length; i++)
        {
            sectionRenderers[i].enabled = false;
            sectionStates[i] = SECTION_STATE.MISSING;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
