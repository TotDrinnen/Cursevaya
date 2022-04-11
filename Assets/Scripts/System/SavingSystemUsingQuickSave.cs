using CI.QuickSave;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystemUsingQuickSave : MonoBehaviour
{
    private Enemy[] enemies;
    private UsableItem[] usableItems;
    private void Start()
    {   
        enemies = GameObject.FindObjectsOfType<Enemy>();
        usableItems = GameObject.FindObjectsOfType<UsableItem>();
    }
    public void SaveGame(string savename) 
   {
        QuickSaveWriter writer = QuickSaveWriter.Create("Saves")
            .Write<string>($"{savename}", savename);
        writer.Commit();
        
        QuickSaveGlobalSettings.StorageLocation =Application.persistentDataPath+$"/{savename}/";
        SaveAllEnemies();
       // SaveUsableItems();
   }

    private void SaveAllEnemies()
    {
        
        foreach (Enemy enemy in enemies)
        {
            enemy.Save();
        }
        
    }
    private void SaveUsableItems() 
    {
        foreach (UsableItem item in usableItems) item.Save();
    }
    private void LoadAllEnemies() 
    {
        foreach (Enemy enemy in enemies)
        {
            
            QuickSaveReader reader = QuickSaveReader.Create($"{enemy.GetInstanceID().ToString()}");
            enemy.Load(reader);
        }
    }
    public void LoadSave(string savename) 
    {
        QuickSaveGlobalSettings.StorageLocation = Application.persistentDataPath + $"/{savename}/";
        LoadAllEnemies();
       // LoadUsableItems();
    }
    private void LoadUsableItems()
    {
        foreach (UsableItem item in usableItems) 
        { 
            QuickSaveReader reader = QuickSaveReader.Create($"{item.GetInstanceID().ToString()}");
            item.Load(reader);
        }
    }
}
