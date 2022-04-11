using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour,IInteractable
{   [SerializeField]
    private Animator animator;


    public void Interact(GameObject interactor, bool isPlayer)
    {
        if (animator.GetBool("IsOpened")) animator.SetBool("IsOpened", false);
        else animator.SetBool("IsOpened", true);              
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
