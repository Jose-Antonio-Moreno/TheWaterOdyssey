using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIShell : MonoBehaviour
{
    public triggerEnemies managerEnemies;
    private bool doneCounter;

    public NavMeshAgent agent;
   
    private Transform player;
    private sizePlayer lifePlayer;

    public LayerMask Ground, Player;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange = false;

    public float hp;

    //Checker
    public bool isHit;

    //particle System
    public ParticleSystem poisonParticles;
    public ParticleSystem deathParticles;
    public ParticleSystem dropiParticles;
    public ParticleSystem iceParticles;

    //Drops
    public GameObject healBubble;
    public GameObject coin;
    private bool droppedHealing = false;

    //Sounds
    public AudioSource splash;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lifePlayer = player.GetComponent<sizePlayer>();
        agent = GetComponent<NavMeshAgent>();

        hp = 120;
        isHit = false;
        //managerEnemies.counter+=1;
        doneCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        //if (playerInSightRange && playerInAttackRange) AttackPlayer();

        this.transform.LookAt(player.position);

        if (hp <= 0)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Invoke("Death", 0.1f);
            if (!droppedHealing)
            {
                int number = Random.Range(0, 5);
                //Debug.Log(number);
                switch (number)
                {
                    case 0:
                        Instantiate(healBubble, transform.position, Quaternion.identity);
                        break;
                    default:
                        break;
                }
                droppedHealing = true;
            }
        }
    }

    void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint Reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //check if this point is on the ground (or outside the map)
        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))
        {
            walkPointSet = true;
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            splash.Play();
            float colorTime = 0.1f;
            var sequence = DOTween.Sequence();
            sequence.Insert(0,gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.red, colorTime));
            sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
            hp -= other.GetComponent<BulletScript>().damage;

            isHit = true;
        }

        if (other.CompareTag("BigDrop"))
        {
            float colorTime = 0.1f;
            var sequence = DOTween.Sequence();
            sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.red, colorTime));
            sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
            hp -= other.GetComponent<BulletScript>().damage;
            isHit = true;
        }
    }
    
    private void Death()
    {
        if (!doneCounter)
        {
            //managerEnemies.counter -= 1;
            doneCounter = true;
        }
        Destroy(this.gameObject);
    }
}
