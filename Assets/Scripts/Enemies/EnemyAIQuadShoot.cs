using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIQuadShoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint1, firePoint2, firePoint3, firePoint4;
    
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
    bool droped;

    //Particles
    public ParticleSystem posionParticles;
    public ParticleSystem deathParticles;

    //Drops
    public GameObject healBubble;
    public GameObject coin;

    //Sounds
    public AudioSource shoot;
    public AudioSource impact;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hp = 70;
        isHit = false;
        nextShoot = 0;
        fireRate = 0.8f;
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
            impact.Play();
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
        Vector3 direction1 = (firePoint1.position - this.transform.position).normalized;
        Vector3 direction2 = (firePoint2.position - this.transform.position).normalized;
        Vector3 direction3 = (firePoint3.position - this.transform.position).normalized;
        Vector3 direction4 = (firePoint4.position - this.transform.position).normalized;
        
        GameObject aux = Instantiate(shootPrefab, gameObject.transform.position + direction1 * 1f, Quaternion.identity);
        GameObject aux2 = Instantiate(shootPrefab, gameObject.transform.position + direction2 * 1f, Quaternion.identity);
        GameObject aux3 = Instantiate(shootPrefab, gameObject.transform.position + direction3 * 1f, Quaternion.identity);
        GameObject aux4 = Instantiate(shootPrefab, gameObject.transform.position + direction4 * 1f, Quaternion.identity);
        
        Vector3 shootForce = direction1 * 80;
        Vector3 shootForce2 = direction2 * 80;
        Vector3 shootForce3 = direction3 * 80;
        Vector3 shootForce4 = direction4 * 80;
        aux2.GetComponent<Rigidbody>().AddForce(shootForce2);
        aux3.GetComponent<Rigidbody>().AddForce(shootForce3);
        aux4.GetComponent<Rigidbody>().AddForce(shootForce4);
        aux.GetComponent<Rigidbody>().AddForce(shootForce);
    }



}
