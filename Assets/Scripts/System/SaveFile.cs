using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class SaveFile : MonoBehaviour
{   [System.NonSerialized]
    private ISaveable[] saveables;
    private Data[] savedData;
    // Start is called before the first frame update
    public SaveFile() {

        saveables = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToArray();
        for (int i = 0; i < saveables.Length; i++)
        {
           
            // savedData.Add(saveable.GetData());
        }
    }
}
