using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenUI : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private UIManager uIManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
        this.gameObject.SetActive(false);
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
    }

    private void Restart()
    {
        uIManager.gameManager.ReloadScene();
        Time.timeScale = 1f;
    }
    private void Exit()
    {
        Application.Quit();
    }
}
