using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInteractor : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Gun gun;
    
    
    public void Interact(GameObject interactor,bool isPlayer)
    {
        gun.Interact(interactor,isPlayer);
    }
}