using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI ammoText;
    [SerializeField]
    private TextMeshProUGUI enemyRemainingText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHP(float value) { healthText.text = $"HP: {value}"; }
    public void SetAmmo(int ammo,int maxAmmo) { ammoText.text = $"{ammo}/{maxAmmo}"; }
    public void SetEnemyRemaining(int enemyRemain) { enemyRemainingText.text = $"{enemyRemain} remain"; }
}
