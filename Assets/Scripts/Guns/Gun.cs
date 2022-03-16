using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour,IInteractable
{
    
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
    
   
    private Coroutine shootingCoroutine;
    private void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
    }
    public void SetHandle(bool isPlayer) { isPlayerHandle = isPlayer; }

    public void Interact(GameObject interactor,bool isPlayerInteract)
    {
        if (isHolded==false)
        {
            Debug.Log("INteract");
            isPlayerHandle = isPlayerInteract;
            isHolded = true;
            gunRigidBody.useGravity = false;
            gunRigidBody.velocity = Vector3.zero;
            //Vector3 handlepos =new Vector3(handle.transform.localPosition.x, handle.transform.localPosition.y, handle.transform.localPosition.z);
            gameObject.transform.rotation = interactor.transform.rotation;
            gameObject.transform.position =interactor.transform.position- handle.transform.localPosition;
            //   gameObject.transform.position = interactor.transform.position;
            //  gameObject.transform.localPosition = handlepos;
           // gameObject.transform.position = interactor.transform.localPosition - handle.transform.localPosition;
            gameObject.transform.SetParent(interactor.transform);
            gameManager.ChangePlayerCurrentGun(this);
            
        }
    }
    public void Shoot( )
    {
        
        if (isHolded) 
        {
           shooter.Shoot(isPlayerHandle);
            
        }

    }
    public void Drop()
    {   
        transform.parent = null;
        gunRigidBody.useGravity = true;
        isHolded = false;
        gameManager.ChangePlayerCurrentGun();

    }
    public void changeHold() { isHolded = true; }
    public GameManager GetGameManager() { return gameManager; }
    
}
