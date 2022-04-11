using CI.QuickSave;
using Panda;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IHitable,ISaveable
{
    [Task]
    public bool isReloaded;
    
    [SerializeField]
    private float maxHealthPoints;
    private float healthPoints;
    [SerializeField]
    private EnemyMovement enemyMovement;
    [SerializeField]
    private EnemyState enemyState;
    [SerializeField]
    private GameManager gameManager;
    private Player player;
    [Task]
    bool isAttacking=false;
    [Task]
    private bool isAlive=true;
    [SerializeField]
    private Gun currentGun;
    private Coroutine shootingCoroutine;
    [SerializeField]
    private float shootingDelay;
    [SerializeField]
    private CharacterController charController;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private GameObject hand;
    private bool isStartShooting = false;
    private float meleeDamage=10f;
    private float maxDistanceReach=4f;
    EnemySaveData enemySaveData;
    [Task]
    private bool isAttacked;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        healthPoints = maxHealthPoints;
        //currentGun.changeHold();
        //currentGun.SetHandle(false);
        currentGun.Interact(hand, false);
  
    }

    // Update is called once per frame
    void Update()
    {
      //  if (isAttacking&&isAlive) Attack();
        if(!charController.isGrounded) charController.Move(Vector3.down * gravity * Time.deltaTime);
    }
    [Task]
    public void MoveToEnemy()
    {
        if (isAlive)
        {
            enemyMovement.MoveToTarget(gameManager.GetPlayer().gameObject);
            isAttacking = true;
        }
    }
    [Task]
    private void Attack()
    {
        player = gameManager.GetPlayer();
        transform.LookAt(player.transform);
        hand.transform.LookAt(player.transform);
        if(!isStartShooting) shootingCoroutine= StartCoroutine(ShootingCoroutine());
        isAttacking = true;
        ThisTask.Succeed();

    }
    public float GetHp()
    {
        return healthPoints;
    }
    public bool IsAlive() { return isAlive; }
    public bool IsAttacking() { return isAttacking; }
    public void GetHit(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0) Die();
        else isAttacked = true;
    }
    public void Die() 
    {
        currentGun.Drop();
        isAlive = false;
        enemyState.setAlive(false);
        gameObject.SetActive(false);
        gameManager.DecreaseEnemyRemain();
    }
    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            isStartShooting = true;
            
            if (currentGun != null) currentGun.Shoot();
            else MeleeAttack();
            yield return new WaitForSeconds(shootingDelay);
            
        }
    }
    private void MeleeAttack() 
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit raycast, maxDistanceReach);

        try
        {
            var hitable = raycast.transform.gameObject.GetComponent<IHitable>() ?? raycast.transform.gameObject.GetComponentInParent<IHitable>();
            hitable.GetHit(meleeDamage);
        }
        catch { Debug.Log("Not Hitable"); }
    }

    public void Save()
    {
        enemySaveData = new EnemySaveData(this);
        enemySaveData.CommitParameters();
    }

    public void Load(QuickSaveReader reader)
    {
        gameObject.SetActive(isAlive);
        isReloaded = false;
        enemySaveData.ReadData(reader);
        isAlive = enemySaveData.isAlive;
        isAttacking = enemySaveData.isAttacking;
        healthPoints = enemySaveData.hp;
        this.transform.position = enemySaveData.position;
        this.transform.rotation = enemySaveData.quaternion;
        currentGun.Interact(hand, false);

    }
    [Task]
    public void Reload() { isReloaded = true;
        ThisTask.Succeed(); }
}
