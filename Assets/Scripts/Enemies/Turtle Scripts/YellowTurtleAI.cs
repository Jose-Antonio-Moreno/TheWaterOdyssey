using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YellowTurtleAI : MonoBehaviour
{
    public triggerEnemies managerEnemies;
    private bool doneCounter;

    public NavMeshAgent agent;

    private Transform player;
    private sizePlayer lifePlayer;

    public LayerMask Ground, Player;

    //Variables
    public int maxDistance;

    //Other enemies
    Transform nearEnemy;

    //States
    public float sightRange;
    public bool playerInSightRange;
    public bool playerInAttackRange = false;

    public float hp;

    //Checker
    public bool isHit;

    //particle System
    public ParticleSystem poisonParticles;
    public ParticleSystem deathParticles;
    public ParticleSystem dropiParticles;

    //Drops
    public GameObject healBubble;
    public GameObject coin;

    //Sounds
    public AudioSource splash;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nearEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        lifePlayer = player.GetComponent<sizePlayer>();
        agent = GetComponent<NavMeshAgent>();

        hp = 90;
        isHit = false;
        //managerEnemies.counter += 1;
        doneCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();

        //KeepDistance();

        if (hp <= 0)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Invoke("Death", 0.1f);
        }
    }
    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    //void KeepDistance() 
    //{
    //    // Modul del vector
    //    float aux  = Vector3.Distance(nearEnemy.transform.position, this.transform.position);
    //    if (aux <= maxDistance) 
    //    {
    //        transform.position = (transform.position - nearEnemy.transform.position).normalized * aux + nearEnemy.transform.position;
    //    }
    //}


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
        //if (!doneCounter)
        //{
        //    managerEnemies.counter -= 1;
        //    doneCounter = true;
        //}
        Destroy(this.gameObject);
    }
}
