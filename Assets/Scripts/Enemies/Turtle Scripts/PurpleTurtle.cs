using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PurpleTurtle : MonoBehaviour
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
    private Transform nearEnemy;

    //States
    public float sightRange;
    public bool playerInSightRange;
    public bool playerInAttackRange = false;

    public float hp;

    //Firepoints
    public Transform[] firepoints;

    //Checker
    public bool isHit;

    //particle System
    public ParticleSystem poisonParticles;
    public ParticleSystem deathParticles;

    //Shoot
    public GameObject shootPrefab;

    //Drops
    public GameObject healBubble;
    public GameObject coin;
    private bool droppedHealing = false;

    //Sounds
    public AudioSource splash;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nearEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        lifePlayer = player.GetComponent<sizePlayer>();
        agent = GetComponent<NavMeshAgent>();

     
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
            if (!droppedHealing)
            {
                int number = Random.Range(0, 5);
                Debug.Log(number);
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
    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    //void KeepDistance()
    //{
    //    // Modul del vector
    //    float aux = Vector3.Distance(nearEnemy.transform.position, this.transform.position);
    //    if (aux <= maxDistance)
    //    {
    //        transform.position = (transform.position - nearEnemy.transform.position).normalized * aux + nearEnemy.transform.position;
    //    }
    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //splash.Play();
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

    private void Explosion()
    {
        //shoot.Play();
        
        for (int i = 0; i < firepoints.Length; i++) 
        {
            Vector3 direction1 = (firepoints[i].position - this.transform.position).normalized;
            GameObject aux = Instantiate(shootPrefab, gameObject.transform.position + direction1 * 1f, Quaternion.identity);
            Vector3 shootForce = direction1 * 80;
            aux.GetComponent<Rigidbody>().AddForce(shootForce);
        }
    }
    private void Death()
    {
        Explosion();
        Destroy(this.gameObject);
        //if (!doneCounter)
        //{
        //    managerEnemies.counter -= 1;
        //    doneCounter = true;
        //}
    }
}
