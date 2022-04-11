using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SavingSystemOnJSON : MonoBehaviour
{
    private Data[] savedData;
   // private List<Data> savedData;
    private ISaveable[] saveables;
    private string jsonSave;
    // Start is called before the first frame update
    void SaveData()
    {
        saveables = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToArray();
        savedData = new Data[saveables.Length];
        for(int i =0;i<saveables.Length;i++)
        {
            
            jsonSave += JsonUtility.ToJson(savedData[i]);
           // savedData.Add(saveable.GetData());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
