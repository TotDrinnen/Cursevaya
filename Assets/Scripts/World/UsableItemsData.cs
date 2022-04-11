using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItemsData : Data
{
    private bool active;
    private int id;
    public UsableItemsData(UsableItem item) 
    {
        active = item.gameObject.activeSelf;
        id = item.GetInstanceID();
    }
    public void CommitActive() {
        QuickSaveWriter writter = QuickSaveWriter.Create($"{id.ToString()}");
        writter.Write<int>("Id", id);
        writter.Write<bool>("Active", active);
    }
    public bool ReadData(QuickSaveReader reader) { reader.Read<bool>("Active", r => { active = r; });
        return active;
    }
}
