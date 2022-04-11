using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour,IHitable,ISaveable
{
    [SerializeField]
    private float health;
    public void GetHit(float damage)
    {
        health -= damage;
        if (health <= 0) { gameObject.SetActive(false); }
    }

    public void Load(QuickSaveReader reader)
    {
        throw new System.NotImplementedException();
    }

    public void Save()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

}
