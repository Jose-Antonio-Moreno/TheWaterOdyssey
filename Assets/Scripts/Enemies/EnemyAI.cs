using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
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

    //Checker
    public bool isHit;

    //Particles
    public ParticleSystem posionParticles;
    public ParticleSystem deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hp = 4;
        isHit = false;
        nextShoot = 0;
        fireRate = 0.5f;
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
            Instantiate(deathParticles, transform.position, Quaternion.identity);
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
            float colorTime = 0.1f;
            var sequence = DOTween.Sequence();
            sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.red, colorTime));
            sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
            hp--;
            isHit = true;
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
    void Shoot()
    {
        Vector3 direction = (player.position - this.transform.position).normalized;
        GameObject aux = Instantiate(shootPrefab, gameObject.transform.position + direction * 1f, Quaternion.identity);
        Vector3 shootForce = direction * 50;
        aux.GetComponent<Rigidbody>().AddForce(shootForce);
    }
}
