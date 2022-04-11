using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private HUD playerHUD;
    private int enemyRemain;
    [SerializeField]
    
    public UIManager uIManager;
    private int EnemyRemain { get { return enemyRemain; } set { enemyRemain = value; SetHUDEnemyRemain(value); } }
    
    

    // Start is called before the first frame update
    void Start()
    {   
        try
        {
            EnemyRemain = GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
        catch { Debug.Log("No More Enemy"); }
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void ChangePlayerCurrentGun(Gun gun)
    {
       
        player.PickGun(gun);
        
    }
    public void ChangePlayerCurrentGun( )
    {
        player.PickGun();
        SetHUDPlayerAmmo(0, 0);
    }
    public Player GetPlayer() { return player; }
    public void DecreaseEnemyRemain() { enemyRemain=-1; }
    private void SetHUDEnemyRemain(int newRemain)
    { playerHUD.SetEnemyRemaining(enemyRemain); }
    
    public void SetHUDPlayerAmmo(int ammo,int maxAmmo) { playerHUD.SetAmmo(ammo, maxAmmo); }
    public void SetPlayerHealth(float health) { playerHUD.SetHP(health); }
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void PlayerDie()
    {   
        uIManager.OpenDeathScreenUI();
    }
}
