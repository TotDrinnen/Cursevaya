using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    [SerializeField]
    private bool isInteractable;
    [SerializeField]
    private GameObject hinge;
    private bool isOpened=false;
    private Coroutine openCoroutine;
    private Coroutine openingCoroutine;
    [SerializeField]
    private float openTime=1;
    private Quaternion doorClose;
    private Quaternion doorOpen;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        doorClose = new Quaternion(0, -90, 0, 0);
        doorOpen = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator OpeningCoroutine()
    {
        while (true)
        {
            if(isOpened)hinge.transform.rotation = Quaternion.Lerp(doorOpen, doorClose, timer);
            else hinge.transform.rotation = Quaternion.Lerp(doorClose, doorOpen, timer);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
            
        }
    }
    private IEnumerator OpenCoroutine()
    {
        while (true)
        {
            isInteractable = false;
            openingCoroutine = StartCoroutine("OpeningCoroutine");
            yield return new WaitForSeconds(openTime);
            StopCoroutine("OpeningCoroutine");
            timer = 0;
            isInteractable = true;
            isOpened = isOpened ? false : true;
            StopCoroutine("OpenCoroutine");

        }
    }
    public void Interact(GameObject interactor, bool isPlayer)
    {   if (isInteractable)
            openCoroutine = StartCoroutine("OpenCoroutine");
    }
}
