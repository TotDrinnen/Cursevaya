using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Gun gun;
    private int ammo;
    [SerializeField]
    private float heroAccuracy;
    [SerializeField]
    private float nonHeroAccuracy;
    [SerializeField]
    private ObjectPool<RayCastProjectile> projectilePool;
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private int bulletsPerShoot=1;
    private Vector3 bulletspread;

    // Start is called before the first frame update
    void Start()
    {
        ammo = gun.maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        projectilePool = new ObjectPool<RayCastProjectile>(CreateProjectile);
    }
    public void Shoot(bool isPlayershoot)
    {
        if (ammo > 0)
        {

            ammo--;
            float accuracy = isPlayershoot ? heroAccuracy : nonHeroAccuracy;
            // Vector3 shootRandom = Random.insideUnitCircle * accuracy;
            for (int i =0;i<bulletsPerShoot;i++) 
            {
                bulletspread = Random.insideUnitCircle*accuracy;
                var projectile = projectilePool.GetObjectFromPool();
                projectile.gameObject.transform.position = transform.position+bulletspread;
                projectile.gameObject.transform.rotation = transform.rotation;
                projectile.setDamage(damage);
                projectile.Launch();
                projectilePool.ReturnObjectToPool(projectile);

            }
        }
        else {
            if (isPlayershoot) gun.Drop();
            else Reload();
                }
        if (isPlayershoot) { gun.GetGameManager().SetHUDPlayerAmmo(ammo, gun.maxAmmo); }    

    }
    public void Reload()
    {
        StartCoroutine("ReloadCoroutine");
        gun.StopShootingCoroutine();
    }
    protected virtual RayCastProjectile CreateProjectile()
    {
        return Instantiate(projectilePrefab).GetComponent<RayCastProjectile>();
        
    }
    private IEnumerator ReloadCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(reloadTime);
            ammo = gun.maxAmmo;
            StopCoroutine("ReloadCoroutine");
        }
    }
    public void ChangeAmmo()
    {
        ammo = gun.maxAmmo;
    }
    public int getAmmo() { return ammo; }
    
       
    
}
