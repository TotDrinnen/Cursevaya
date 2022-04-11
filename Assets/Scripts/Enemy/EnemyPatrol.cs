using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private GameObject[] patrolpoints;
    private GameObject patrolPoint;
    private int patrolIndex = 0;
    [SerializeField]
    private float patrolDelay;
    private Coroutine patrolCoroutine;
    private bool isMoving;
    [Task]
    private void StartPatrol()
    {
        navMeshAgent.stoppingDistance = 0;
        ThisTask.Succeed();
    }
    [Task]
    private void SetIndex()
    {
        patrolIndex = patrolIndex == patrolpoints.Length - 1 ? 0 : patrolIndex++;
        ThisTask.Succeed();

    }
    [Task]
    private void SetWayPoint() {
      
        patrolPoint = patrolpoints[patrolIndex];
        
    
        ThisTask.Succeed();
    }
    [Task]
    private void MoveToNextWayPoint()
    {
        navMeshAgent.SetDestination(patrolPoint.transform.position);

        if(!navMeshAgent.hasPath)
        ThisTask.Succeed();
        }
    }
   

    

