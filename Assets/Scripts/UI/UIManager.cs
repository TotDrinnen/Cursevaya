using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField]
    private HUD playerHUD;
    [SerializeField]
    private DeathScreenUI deathScreenUI;
    [SerializeField]
    private MenuUI menuUI;
    private bool isMenuOpened=false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    public void OpenDeathScreenUI() 
    {
        Time.timeScale = 0f;
        playerHUD.gameObject.SetActive(false);
        deathScreenUI.gameObject.SetActive(true);
        menuUI.gameObject.SetActive(false);
    }
    public void OpenMenuUI() 
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.SetInMenu(true);
        Time.timeScale = 0;
        menuUI.gameObject.SetActive(true);
        isMenuOpened = true;
    }
    public void HideMenuUI() 
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.SetInMenu(false);
        Time.timeScale = 1;
        menuUI.gameObject.SetActive(false);
        isMenuOpened = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!isMenuOpened) OpenMenuUI();
            else HideMenuUI();

        }
    }
}
