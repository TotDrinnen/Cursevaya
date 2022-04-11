using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour,IInteractable
{
    [SerializeField]
    private bool isInteractable=true;
    public int maxAmmo;
    [SerializeField]
    GameManager gameManager;
    private bool isHolded;
    [SerializeField]
    private Shooter shooter;
    [SerializeField]
    private Rigidbody gunRigidBody;
    [SerializeField]
    private GameObject handle;
    [SerializeField]
    private float rateOfFire;
    private bool isPlayerHandle;
    [SerializeField]
    private Collider collider;
    [SerializeField]
    private bool isFullAuto;
    private bool isHold;//For Full auto realization
    
    
   
    private Coroutine shootingCoroutine;
    private Coroutine destroyCoroutine;
    private void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
    }
    public void SetHandle(bool isPlayer) { isPlayerHandle = isPlayer; }
    public void SetHold(bool isHold) { this.isHold = isHold; }
    public void Interact(GameObject interactor,bool isPlayerInteract)
    {
        if (isInteractable)
        {
            if (!isHolded)
            {
                isInteractable = false;
                collider.isTrigger = true;
                Debug.Log("INteract");
                isPlayerHandle = isPlayerInteract;
                isHolded = true;
                gunRigidBody.useGravity = false;
                gunRigidBody.velocity = Vector3.zero;
                //Vector3 handlepos =new Vector3(handle.transform.localPosition.x, handle.transform.localPosition.y, handle.transform.localPosition.z);
                gameObject.transform.rotation = interactor.transform.rotation;
                //        gameObject.transform.position =interactor.transform.position- handle.transform.localPosition;
                gameObject.transform.position = interactor.transform.position;
                //  gameObject.transform.localPosition = handlepos;
                // gameObject.transform.position = interactor.transform.localPosition - handle.transform.localPosition;
                gameObject.transform.SetParent(interactor.transform);

                if (isPlayerInteract) 
                { 
                    gameManager.SetHUDPlayerAmmo(maxAmmo, maxAmmo);
                    gameManager.ChangePlayerCurrentGun(this);
                    gameObject.layer =8;
                }
            }
        }
    }
    public void Shoot(  )
    {
          
            if (isHolded)
            { if (!isFullAuto)
                shooter.Shoot(isPlayerHandle);

            else
            {
                shootingCoroutine = StartCoroutine("ShootCoroutine");
            }
            
        }
    }
    public void Drop()
    {
     //   transform.position = transform.forward;
        transform.parent = null;
        gunRigidBody.useGravity = true;
        collider.isTrigger = false;
        isHolded = false;
        gameObject.layer = 7;
        if (isPlayerHandle)
        {
            if (shooter.getAmmo() == 0) destroyCoroutine = StartCoroutine("DestroyCoroutine");
            gameManager.ChangePlayerCurrentGun();
        }
        else
        {
            isInteractable = true;
            shooter.ChangeAmmo();
        }
    }
    public void changeHold() { isHolded = true; }
    public GameManager GetGameManager() { return gameManager; }

    private IEnumerator DestroyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Destroy(this.gameObject);
            StopAllCoroutines();
        }
    }
    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            shooter.Shoot(isPlayerHandle);
            yield return new WaitForSeconds(rateOfFire);
        }
    }
    public void StopShootingCoroutine() { StopCoroutine(shootingCoroutine); }
    
    
}
