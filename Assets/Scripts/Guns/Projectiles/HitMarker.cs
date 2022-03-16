using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    private Coroutine disableCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        gameObject.SetActive(true);
        StartCoroutine("Disabler");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Disabler()
    {
        while (true)
        {            
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }
}
