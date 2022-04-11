using Panda;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private float distanceToStop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveToTarget(GameObject target)
    {
        navMeshAgent.stoppingDistance = distanceToStop;
        navMeshAgent.SetDestination(target.transform.position);
        
        
    }
    
}
