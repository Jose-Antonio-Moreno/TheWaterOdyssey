using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public triggerEnemies managerEnemies;
    private bool doneCounter;

    public NavMeshAgent agent;

    public LayerMask Ground;

    public float hp;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Bullet
    public GameObject shootPrefab;
    private float nextShoot;
    private float fireRate;

    //Player
    private Transform player;
    private sizePlayer lifePlayer;
    private bool hitted;

    //Checker
    public bool isHit;
    bool droped;

    //Particles
    public ParticleSystem posionParticles;
    public ParticleSystem deathParticles;

    //Drops
    public GameObject healBubble;
    public GameObject coin;

    //Sounds
    public AudioSource splash;
    public AudioSource shoot;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lifePlayer = player.GetComponent<sizePlayer>();
        //Slime Health (damage Basic Shoot = 10)
        hp = 50;
        isHit = false;
        nextShoot = 0;
        fireRate = 0.5f;
        hitted = false;
        managerEnemies.counter += 1;
        doneCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        Patroling();

        if (Time.time >= nextShoot)
        {
            nextShoot = Time.time + 1f / fireRate;
            Shoot();
        }

        if (hp <= 0)
        {
            droped = true;
            Instantiate(deathParticles, transform.position, Quaternion.identity);

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
        if (!doneCounter)
        {
            managerEnemies.counter -= 1;
            doneCounter = true;
        }
        
        Destroy(this.gameObject);
    }

    private void Drop() 
    {
        //Falta rotar la moneda
        int number = Random.RandomRange(0, 2);
        switch (number)
        {
            case 0:
                Instantiate(healBubble, transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(coin, transform.position, Quaternion.identity);
                break;
            case 2:
                break;
        }
    }

    void Shoot()
    {
        shoot.Play();
        Vector3 direction = (player.position - this.transform.position).normalized;
        Vector3 bulletPosition = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
        GameObject aux = Instantiate(shootPrefab, bulletPosition + direction * 1f, Quaternion.identity);
        Vector3 shootForce = direction * 50;
        aux.GetComponent<Rigidbody>().AddForce(shootForce);
    }
}
