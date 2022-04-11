using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Button savebutton;
    [SerializeField]
    private Button loadbutton;
    [SerializeField]
    private Button quitbutton;
    private SavingSystemUsingQuickSave savingSystem;
    [SerializeField]
    private InputField saveField;
    [SerializeField]
    private InputField loadField;
    [SerializeField]
    private Dropdown drop;
    // Start is called before the first frame update
    void Start()
    {
        savebutton.onClick.AddListener(Save);
        loadbutton.onClick.AddListener(Load);
        quitbutton.onClick.AddListener(Exit);
        savingSystem =FindObjectOfType<SavingSystemUsingQuickSave>();
        gameObject.SetActive(false);
        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath+"/QuickSave/");
        FileInfo[] fileInfo = info.GetFiles();
        foreach(FileInfo file in fileInfo) 
        {
            Dropdown.OptionData newOption = new Dropdown.OptionData();
            newOption.text = file.Name;
            
                
        }
    }
    private void Save() { savingSystem.SaveGame(saveField.text); }
    private void Load() 
    { 
        int value = drop.value;
        //savingSystem.LoadSave(drop.options[value].text);
        savingSystem.LoadSave(saveField.text);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void AddSavetoDrop(string save) 
    {
        Dropdown.OptionData newOption = new Dropdown.OptionData();
        newOption.text = saveField.text;
    }
    private void Exit() { Application.Quit(); }
}
