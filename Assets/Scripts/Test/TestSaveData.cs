using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveData : Data
{
    private float positionx;
    private float positiony;
    private float positionz;
    // Start is called before the first frame update
    public TestSaveData(GameObject testObject) 
    {
        positionx = testObject.transform.position.x;
        positiony = testObject.transform.position.y;
        positionz = testObject.transform.position.z;
    }
}
