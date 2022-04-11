using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsableItem : MonoBehaviour,IInteractable,ISaveable
{
    private UsableItemsData usableItemData;

    public  void Interact(GameObject interactor, bool isPlayer)
    {
        throw new System.NotImplementedException();
    }

    public void Load(QuickSaveReader reader)
    {
        this.gameObject.SetActive(usableItemData.ReadData(reader));
    }

    public void Save()
    {
        usableItemData = new UsableItemsData(this);
        usableItemData.CommitActive();
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
