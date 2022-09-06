using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy2 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public GameObject projectile; 
    public float health;
    public float readyPosition;
    public GameObject enemyGun;
    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform attackPoint3;
    // patrolling
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttack;

    //state
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) 
            // Debug.Log("hello patrol");
            Patrolling();
        if(playerInSightRange && !playerInAttackRange)
            ChasePlayer();
            
        if(playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patrolling()
    {
        if (!walkPointSet) 
            SearchWalkPoint();
        if(walkPointSet)
            agent.SetDestination(walkpoint);
        
        Vector3 distanceToWalkpoint = transform.position - walkpoint;

        //walkpoint reached
        if(distanceToWalkpoint.magnitude < readyPosition)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ =Random.Range(-walkPointRange, walkPointRange);
        float randomX =Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttack)
        {
            //attack code
            GameObject currentBullet = Instantiate(enemyGun, attackPoint.position, Quaternion.identity);
            currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 32f, ForceMode.Impulse);

            GameObject currentBullet2 = Instantiate(enemyGun, attackPoint2.position, Quaternion.identity);
            currentBullet2.GetComponent<Rigidbody>().AddForce(transform.forward * 32f, ForceMode.Impulse);

            GameObject currentBullet3 = Instantiate(enemyGun, attackPoint3.position, Quaternion.identity);
            currentBullet3.GetComponent<Rigidbody>().AddForce(transform.forward * 32f, ForceMode.Impulse);

            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <=0) Invoke(nameof(DestroyEnemy), 5f);

    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
