using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private HUD playerHUD;
    private int enemyRemain { get { return enemyRemain; } set { SetHUDEnemyRemain(value); } }

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            enemyRemain = GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
        catch { Debug.Log("No More Enemy"); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePlayerCurrentGun(Gun gun)
    {
       
        player.PickGun(gun);
    }
    public void ChangePlayerCurrentGun( )
    {
        player.PickGun();
    }
    public Player GetPlayer() { return player; }
    public void DecreaseEnemyRemain() { enemyRemain=-1; }
    private void SetHUDEnemyRemain(int newRemain)
    { playerHUD.SetEnemyRemaining(enemyRemain); }
    
    public void SetHUDPlayerAmmo(int ammo,int maxAmmo) { playerHUD.SetAmmo(ammo, maxAmmo); }
    public void SetPlayerHealth(float health) { playerHUD.SetHP(health); }
}
