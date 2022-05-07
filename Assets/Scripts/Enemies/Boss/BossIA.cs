using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossIA : MonoBehaviour
{
   
    public LayerMask Ground, Player;

    public float hp;
    public NavMeshAgent agent;


    [SerializeField]
    Transform fireTriple, fireTriple2, fireTriple3;
    [SerializeField]
    Transform fireShootgun, fireShootgun1, fireShootgun2, fireShootgun3;
    [SerializeField]
    Transform fireStar, fireStar1, fireStar2, fireStar3, fireStar4, fireStar5, fireStar6, fireStar7;

    //Bullet
    public GameObject shootPrefab;
    private float nextShoot;
    private float fireRate;

    private float starShootTime;
    int count;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float attackRange;
    
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

    //Sounds
    public AudioSource splash;
    public AudioSource shoot;

    private float number;

    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lifePlayer = player.GetComponent<sizePlayer>();
        //Slime Health (damage Basic Shoot = 10)
        hp = 300;
        isHit = false;
        nextShoot = 0;
        fireRate = 0.3f;
        hitted = false;
        //managerEnemies.counter += 1;
       
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        this.transform.LookAt(player.position);

        Patroling();
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
               
                Shoot();
            }

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

    void Shoot()
    {

        int randomNum = Random.Range(0, 3);
        Debug.Log("Random NUM:  " +randomNum);
        switch (randomNum) {

            case 0:
               
                Vector3 direction1 = (fireTriple.position - this.transform.position).normalized;
                Vector3 direction2 = (fireTriple2.position - this.transform.position).normalized;
                Vector3 direction3 = (fireTriple3.position - this.transform.position).normalized;

                GameObject aux = Instantiate(shootPrefab, gameObject.transform.position + direction1 * 1f, Quaternion.identity);
                GameObject aux2 = Instantiate(shootPrefab, gameObject.transform.position + direction2 * 1f, Quaternion.identity);
                GameObject aux3 = Instantiate(shootPrefab, gameObject.transform.position + direction3 * 1f, Quaternion.identity);

                Vector3 shootForce = direction1 * 80;
                Vector3 shootForce2 = direction2 * 80;
                Vector3 shootForce3 = direction3 * 80;

                aux.GetComponent<Rigidbody>().AddForce(shootForce);
                aux2.GetComponent<Rigidbody>().AddForce(shootForce2);
                aux3.GetComponent<Rigidbody>().AddForce(shootForce3);

                nextShoot = Time.time + number / fireRate;
                break;

            case 1:
                
                Vector3 shootGunDir = (fireShootgun.position - this.transform.position).normalized;
                Vector3 shootGunDir1 = (fireShootgun1.position - this.transform.position).normalized;
                Vector3 shootGunDir2 = (fireShootgun2.position - this.transform.position).normalized;
                Vector3 shootGunDir3 = (fireShootgun3.position - this.transform.position).normalized;
                
                
                GameObject shootGunAux = Instantiate(shootPrefab, gameObject.transform.position + shootGunDir * 1f, Quaternion.identity);
                GameObject shootGunAux1 = Instantiate(shootPrefab, gameObject.transform.position + shootGunDir1 * 1f, Quaternion.identity);
                GameObject shootGunAux2 = Instantiate(shootPrefab, gameObject.transform.position + shootGunDir2 * 1f, Quaternion.identity);
                GameObject shootGunAux3 = Instantiate(shootPrefab, gameObject.transform.position + shootGunDir3 * 1f, Quaternion.identity);
                
                

                Vector3 shootgunForce = shootGunDir * 80;
                Vector3 shootgunForce1 = shootGunDir1 * 80;
                Vector3 shootgunForce2 = shootGunDir2 * 80;
                Vector3 shootgunForce3 = shootGunDir3 * 80;
                

                shootGunAux.GetComponent<Rigidbody>().AddForce(shootgunForce);
                shootGunAux1.GetComponent<Rigidbody>().AddForce(shootgunForce1);
                shootGunAux2.GetComponent<Rigidbody>().AddForce(shootgunForce2);
                shootGunAux3.GetComponent<Rigidbody>().AddForce(shootgunForce3);

                nextShoot = Time.time + number / fireRate;

                break;

            case 2:

                count = 0;
                if (Time.time >= starShootTime)
                {
                    
                    
                    nextShoot = Time.time + 0.05f / fireRate;

                    starShoot();
                }

                
                if(count >=5)nextShoot = Time.time + number / fireRate;

                break;
        
        }


       
    }


    void starShoot() {
        count++;
        Vector3 starDir = (fireStar.position - this.transform.position).normalized;
        Vector3 starDir1 = (fireStar1.position - this.transform.position).normalized;
        Vector3 starDir2 = (fireStar2.position - this.transform.position).normalized;
        Vector3 starDir3 = (fireStar3.position - this.transform.position).normalized;
        Vector3 starDir4 = (fireStar4.position - this.transform.position).normalized;
        Vector3 starDir5 = (fireStar5.position - this.transform.position).normalized;
        Vector3 starDir6 = (fireStar6.position - this.transform.position).normalized;
        Vector3 starDir7 = (fireStar7.position - this.transform.position).normalized;


        GameObject starAux = Instantiate(shootPrefab, gameObject.transform.position + starDir * 1f, Quaternion.identity);
        GameObject starAux1 = Instantiate(shootPrefab, gameObject.transform.position + starDir1 * 1f, Quaternion.identity);
        GameObject starAux2 = Instantiate(shootPrefab, gameObject.transform.position + starDir2 * 1f, Quaternion.identity);
        GameObject starAux3 = Instantiate(shootPrefab, gameObject.transform.position + starDir3 * 1f, Quaternion.identity);
        GameObject starAux4 = Instantiate(shootPrefab, gameObject.transform.position + starDir4 * 1f, Quaternion.identity);
        GameObject starAux5 = Instantiate(shootPrefab, gameObject.transform.position + starDir5 * 1f, Quaternion.identity);
        GameObject starAux6 = Instantiate(shootPrefab, gameObject.transform.position + starDir6 * 1f, Quaternion.identity);
        GameObject starAux7 = Instantiate(shootPrefab, gameObject.transform.position + starDir7 * 1f, Quaternion.identity);


        Vector3 starForce = starDir * 80;
        Vector3 starForce1 = starDir1 * 80;
        Vector3 starForce2 = starDir2 * 80;
        Vector3 starForce3 = starDir3 * 80;
        Vector3 starForce4 = starDir4 * 80;
        Vector3 starForce5 = starDir5 * 80;
        Vector3 starForce6 = starDir6 * 80;
        Vector3 starForce7 = starDir7 * 80;


        starAux.GetComponent<Rigidbody>().AddForce(starForce);
        starAux1.GetComponent<Rigidbody>().AddForce(starForce1);
        starAux2.GetComponent<Rigidbody>().AddForce(starForce2);
        starAux3.GetComponent<Rigidbody>().AddForce(starForce3);
        starAux4.GetComponent<Rigidbody>().AddForce(starForce4);
        starAux5.GetComponent<Rigidbody>().AddForce(starForce5);
        starAux6.GetComponent<Rigidbody>().AddForce(starForce6);
        starAux7.GetComponent<Rigidbody>().AddForce(starForce7);

    }


}
