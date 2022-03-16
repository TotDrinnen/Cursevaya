using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IHitable
{   [SerializeField]
    private GameObject hand;
    [SerializeField]
    private float maxDistanceReach;
    private GameManager gameManager;
    [SerializeField]
    private float maxHealth;
    private float health { get { return health; } set { gameManager.SetPlayerHealth(value); } }


    public Gun currentGun;
    // Start is called before the first frame update
    void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact(IInteractable interactable)
    {
        interactable.Interact(hand,true);
    }
  /*  public void InteractWithObject()
    {
        Physics.Raycast(transform.position, Vector3.forward, out RaycastHit raycast, maxDistanceReach);
        var interactable = raycast.transform.gameObject.GetComponent<IInteractable>() ?? raycast.transform.gameObject.GetComponentInParent<IInteractable>();
        Interact(interactable);
    }*/
    public void PickGun(Gun gun) 
    {
        gameManager.SetHUDPlayerAmmo(gun.maxAmmo,gun.maxAmmo);
        currentGun = gun;
    }
    public void PickGun( )
    {
        currentGun = null;
    }

    public void GetHit(float damage)
    {
        health -= damage;
    }
}
