using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : UsableItem,IInteractable
{
    private GameManager gameManager;
    [SerializeField]
    private float value;

    public  void Interact(GameObject interactor, bool isPlayer)
    {
        var hitable = interactor.GetComponent<IHitable>() ?? interactor.GetComponentInParent<IHitable>();
        hitable.GetHit(-1 * value);
        Destroy(this.gameObject);
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
