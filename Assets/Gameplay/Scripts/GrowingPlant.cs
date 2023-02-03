using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlant : MonoBehaviour
{
    PlantSection[] plantSections;

    public int numOfSections = 3;
    public Mesh sectionMesh;
    public Transform[] sectionTransforms;

    // Start is called before the first frame update
    void Start()
    {
        plantSections = new PlantSection[numOfSections];

        for(int i = 0; i < plantSections.Length; i++)
        {
            if(i < sectionTransforms.Length)
                plantSections[i].sectionTransform = sectionTransforms[i];
            plantSections[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
