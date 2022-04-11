using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{   [SerializeField]
    private MainMenuUI main;
    [SerializeField]
    private Button returnButton;
    [SerializeField]
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        returnButton.onClick.AddListener(ReturnToMainMenu);
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeVolume(float value) { PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }
    private void ReturnToMainMenu() { main.ShowStartMenu(); }
}
