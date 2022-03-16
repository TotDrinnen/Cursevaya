using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IHitable
{
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
    bool isAttacking;
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
        if (isAttacking&&isAlive) Attack();
        if(!charController.isGrounded) charController.Move(Vector3.down * gravity * Time.deltaTime);
    }
    public void MoveToEnemy()
    {
        if (isAlive)
        {
            enemyMovement.MoveToTarget(gameManager.GetPlayer().gameObject);
            isAttacking = true;
        }
    }
    private void Attack()
    {
        player = gameManager.GetPlayer();
        transform.LookAt(player.transform);
        hand.transform.LookAt(player.transform);
        shootingCoroutine= StartCoroutine(ShootingCoroutine());

    }

    public void GetHit(float damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0) Die();
    }
    public void Die() 
    {
        isAlive = false;
        enemyState.setAlive(false);
        gameObject.SetActive(false);
        gameManager.DecreaseEnemyRemain();
    }
    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingDelay);
            currentGun.Shoot();
        }
    }
}
