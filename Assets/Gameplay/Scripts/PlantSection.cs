using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlantSection : MonoBehaviour
{
    public enum SECTION_STATE
    {
        MISSING,
        GROWING,
        GROWN,
        FAILED
    }

    private Mesh mesh;
    public Transform sectionTransform;
    public SECTION_STATE state;

    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        sectionTransform = gameObject.transform;
        state = SECTION_STATE.MISSING;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
