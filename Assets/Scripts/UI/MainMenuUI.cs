using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button exitButton;
    


    // Start is called before the first frame update
    void Start()
    {
        ShowStartMenu();
        exitButton.onClick.AddListener(Exit);
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(ShowSettingsMenu);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowStartMenu() 
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void ShowSettingsMenu()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    private void Exit()
    {
        Application.Quit();
    }
    private void StartGame()
    { SceneManager.LoadScene(1, LoadSceneMode.Single);
      //  SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        
    }
}
