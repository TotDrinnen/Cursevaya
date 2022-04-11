using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestForUIAndCoroutines : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI testtext;
    [SerializeField]
    private float delay;
    private Coroutine coroutine;
    private int testInt=0;
    public int TestInt
    {
        get {return testInt; }
        set { testInt = value; ChangeText(value); }
    }
    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine("TextCoroutine");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator TextCoroutine()
    {
        while (true)
        {
            TestInt++;
            yield return new WaitForSeconds(delay);
        }
    }
    private void ChangeText(int value)
    {
        testtext.text = $"{value}";
    }
}
