using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
    ISaveable[] saveables;
    public void SaveGame(string saveName)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = $"{Application.persistentDataPath}/Saves/{saveName}.savedata";
        Debug.Log($"{Application.persistentDataPath}/Saves/{saveName}.savedata");
        SaveFile saveFile = new SaveFile();
        FileStream stream = File.Create(path);
        formatter.Serialize(stream, saveFile);
        stream.Close();
        
    }
    public static object LoadGame(string path)
    {
        if (!File.Exists(path)) return null;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(path,FileMode.Open);
        try { object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch {Debug.Log("Failed to download save");
            file.Close();
            return null;
        }
    }

}
