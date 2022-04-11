using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IHitable
{
    public bool isAlive=true;
    [SerializeField]
    private GameObject hand;
    [SerializeField]
    private float maxDistanceReach;
    private GameManager gameManager;
    [SerializeField]
    private float maxHealth;
    private float health;
    public float Health { get { return health; } set { health = value; gameManager.SetPlayerHealth(value); } }
    public Gun currentGun;
    public float meleeDamage;
    // Start is called before the first frame update
    void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
        Health = maxHealth;
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
        Health -= damage;
        if (Health <= 0) Die();
        else if (Health > maxHealth) Health = maxHealth;
    }
    public void MeleeAttack()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit raycast, maxDistanceReach);
        try
        {
            var hitable = raycast.transform.gameObject.GetComponent<IHitable>() ?? raycast.transform.gameObject.GetComponentInParent<IHitable>();
            hitable.GetHit(meleeDamage);
        }
        catch { Debug.Log("NotHitable"); }
    }
    private void Die()
    {
        gameManager.uIManager.OpenDeathScreenUI();
    }
}
