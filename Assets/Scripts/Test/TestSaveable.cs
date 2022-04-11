using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveable : MonoBehaviour
{
    TestSaveData testSaveData;
    public Data GetData()
    {
        return testSaveData=new TestSaveData(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
