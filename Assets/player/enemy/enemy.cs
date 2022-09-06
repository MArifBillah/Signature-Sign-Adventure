using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public GameObject projectile; 
    public float health;
    public Slider enemyHealth;
    public float readyPosition;
    GameObject destroyed;
    // patrolling
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttack;
    public GameObject enemyGun;
    public Transform attackPoint;

    //state
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update

    // [Header("animations")]
    // public Animator anim;


    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        // anim.SetBool("enemyRunning",false);
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) 
        {
            Patrolling();
            // anim.SetBool("enemyRunning",true);
        }
        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            // anim.SetBool("enemyRunning",true);
        }
        if(playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
            // anim.SetBool("enemyRunning",true);
        }

        enemyHealth.value = health;
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        // anim = GameObject.Find("battlebots").GetComponent<Animator>();
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
        transform.LookAt(player);
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
            destroyed = currentBullet;
            Destroy(currentBullet, 1f);
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
        // Debug.Log("hello damage");
        health -= damage;
        if (health <=0) Invoke(nameof(DestroyEnemy), 0);

    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void destroyEnemyBullet()
    {
        Destroy(destroyed);
    }
}
