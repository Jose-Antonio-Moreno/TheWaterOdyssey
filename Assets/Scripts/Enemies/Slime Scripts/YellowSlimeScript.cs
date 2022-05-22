using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YellowSlimeScript : MonoBehaviour
{
    public triggerEnemies managerEnemies;
    private bool doneCounter;

    public NavMeshAgent agent;
    public LayerMask Ground, Player;

    public float hp;



    [SerializeField]
    Transform firePoint1, firePoint2, firePoint3;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Bullet
    public GameObject shootPrefab;
    private float nextShoot;
    public float fireRate;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange = false;

    //Player
    private Transform player;
    private sizePlayer lifePlayer;
    private bool hitted;

    //Checker
    public bool isHit;
    bool droped;
    bool moreRange = false;

    //Particles
    public ParticleSystem posionParticles;
    public ParticleSystem deathParticles;
    public ParticleSystem dropiParticles;
    public ParticleSystem iceParticles;

    //Drops
    public GameObject healBubble;
    public GameObject coin;
    private bool droppedHealing = false;

    //Sounds
    public AudioSource splash;
    public AudioSource shoot;

    private float number;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lifePlayer = player.GetComponent<sizePlayer>();
        //Slime Health (damage Basic Shoot = 10)
        hp = 40;
        isHit = false;
        nextShoot = 0;
        fireRate = 0.3f;
        hitted = false;
        //managerEnemies.counter += 1;
        doneCounter = false;
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        this.transform.LookAt(player.position);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();


        if (Vector3.Distance(player.transform.position, this.transform.position) <= attackRange)
        {
            if (!moreRange)
            {
                attackRange += 10;
                moreRange = true;
            }
            if (Time.time >= nextShoot)
            {
                number = Random.Range(0.4f, 0.8f);
                nextShoot = Time.time + number / fireRate;
                Shoot();
            }

        }

        if (hp <= 0)
        {
            droped = true;
            Instantiate(deathParticles, transform.position, Quaternion.identity);
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
            if (droped)
            {
                Invoke("Drop", 0.1f);
                droped = false;
            }

            Invoke("Death", 0.1f);
            //Death();
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
        if (Vector3.Distance(player.transform.position, this.transform.position) <= attackRange)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.SetDestination(player.position);
            agent.isStopped = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            splash.Play();
            float colorTime = 0.1f;
            var sequence = DOTween.Sequence();
            sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.red, colorTime));
            sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
            hp -= other.GetComponent<BulletScript>().damage;
            isHit = true;
        }
        if (other.CompareTag("Player") && !hitted)
        {
            lifePlayer.life--;
            lifePlayer.changed = false;
            hitted = true;
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
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hitted = false;
        }
    }
    private void Death()
    {
        //if (!doneCounter)
        //{
        //    managerEnemies.counter -= 1;
        //    doneCounter = true;
        //}

        Destroy(this.gameObject);
    }


    void Shoot()
    {
        shoot.Play();
        Vector3 direction1 = (firePoint1.position - this.transform.position).normalized;
        Vector3 direction2 = (firePoint2.position - this.transform.position).normalized;
        Vector3 direction3 = (firePoint3.position - this.transform.position).normalized;

        GameObject aux = Instantiate(shootPrefab, gameObject.transform.position + direction1 * 1f, Quaternion.identity);
        GameObject aux2 = Instantiate(shootPrefab, gameObject.transform.position + direction2 * 1f, Quaternion.identity);
        GameObject aux3 = Instantiate(shootPrefab, gameObject.transform.position + direction3 * 1f, Quaternion.identity);

        Vector3 shootForce = direction1 * 80;
        Vector3 shootForce2 = direction2 * 80;
        Vector3 shootForce3 = direction3 * 80;
        
        aux.GetComponent<Rigidbody>().AddForce(shootForce);
        aux2.GetComponent<Rigidbody>().AddForce(shootForce2);
        aux3.GetComponent<Rigidbody>().AddForce(shootForce3);

        //Debug.Log("SHOOT");
    }
}
