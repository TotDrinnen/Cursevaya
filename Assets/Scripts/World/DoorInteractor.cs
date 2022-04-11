using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractor : MonoBehaviour,IInteractable
{
    [SerializeField]
    private NewDoor newDoor;
    public void Interact(GameObject interactor, bool isPlayer)
    {
        newDoor.Interact(interactor, isPlayer);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
