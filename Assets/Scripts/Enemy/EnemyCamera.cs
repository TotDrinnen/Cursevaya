using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamera : MonoBehaviour
{
    [SerializeField]
    private bool isEnabled;
    [SerializeField]
    private float FOV;//Field of View
    private Player player;
    private bool isSeePlayer=false;//value for set attention 
    private float attention=0;//if >=1 - Enemy will see player and attack
    [SerializeField]
    private float attentiveness;
    [SerializeField]
    private EnemyState enemyState;
    [SerializeField]
    private float maxDistanceRange;
    private Vector3 targetToDot;


    // Start is called before the first frame update
    void Start()
    {
        player= FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        LookforPlayer();
       // SetAttention(targetDot);
    }
    private void LookforPlayer()
    {
        Vector3 targetToDot = (player.transform.position - transform.position).normalized;
        float targetDot = Vector3.Dot(transform.forward, targetToDot);
        bool isinFOV = targetDot > FOV;
        Debug.DrawRay(transform.position, targetToDot*10f, Color.red);
        if (isinFOV && Physics.Raycast(transform.position, targetToDot*maxDistanceRange, out RaycastHit hit))
        {
            Debug.Log("ISMustSee");
            if (hit.transform.gameObject.CompareTag("Player")) { isSeePlayer = true; Debug.Log("SeePlayer"); }
            else  isSeePlayer = false; 
        }
        else isSeePlayer = false;
        SetAttention(targetDot);
    }
    private void SetAttention(float range)
    {
        float seeModifier = isSeePlayer ? 1 : -1;
        attention += (seeModifier + Time.deltaTime) / (range*attentiveness);
        if (attention < 0) attention = 0;
        if (attention >= 1) { enemyState.SetAlertStatus(true); }
    }
}
