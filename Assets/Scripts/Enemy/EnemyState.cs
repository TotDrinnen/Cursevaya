using Panda;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyState : MonoBehaviour
{   
    [Task]
    private bool isSeePlayer; //final state with actions
    private bool isAlive;
    [SerializeField]
    private Enemy enemy;
    [Task]
    public bool isPatroller;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
      //  if (isSeePlayer&&isAlive) enemy.MoveToEnemy();
    }
    public bool SetAlertStatus(bool status)
    {
        isSeePlayer = status;
        return status;
    }
    public void setAlive(bool isAlive) { this.isAlive = isAlive; }
}
