using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss : MonoBehaviour
{

   private Transform player;
   
    //Particles
    public ParticleSystem posionParticles;
    public ParticleSystem deathParticles;

    public float maxHp, hp;
    public bool isHit;
    bool droped;
    private sizePlayer lifePlayer;
    private bool hitted;

    //Shoot variables
    public int numOfProjectiles;
    public float projectileSpeed;
    public GameObject shootPrefab;

    Vector3 startPoint;
    float radius = 1.0f;
    float spiralAngle;

    float starShootTimer, invokeTimer, circleShootTimer, invokeTimer2, spiralTimer, spiralTimer2;
    bool startInvoke, startInvoke2;
    int rafagasCount, spiralCount;

    

    [SerializeField]
    Transform fireStar, fireStar1, fireStar2, fireStar3, fireStar4 ;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lifePlayer = player.GetComponent<sizePlayer>();
        hp = maxHp;
        starShootTimer = 2f;
        invokeTimer = 5f;
        invokeTimer2 = 5f;
        circleShootTimer = 5f;
        startInvoke = false;
        startInvoke2 = true;
        rafagasCount = 0;
        spiralCount = 0;
        spiralTimer = 5f;
        isHit = false;
        hitted = false;
}

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.position);
        startPoint = transform.position;

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
            Death();
        }


        if (hp >= maxHp * 0.75f)
        {

            if (Time.time >= starShootTimer)
            {
                float number = Random.Range(3f, 5f);
                starShootTimer = Time.time + number;
                starShoot();
            }
            if (Time.time >= circleShootTimer && startInvoke)
            {

                circleShootTimer = Time.time + 0.6f;
                ShootingOnCicle(10);
                rafagasCount++;

                if (rafagasCount >= 5) startInvoke = false;
            }
            if (Time.time >= invokeTimer)
            {
                invokeTimer = Time.time + 12f;
                rafagasCount = 0;
                if (startInvoke) startInvoke = false;
                else startInvoke = true;
            }

        }
        else if (hp >= maxHp * 0.50f && hp < maxHp * 0.75f)
        {

            spiralTimer -= Time.deltaTime;

            if (spiralTimer <= 0 && startInvoke2)
            {

                spiralShoot();
                spiralTimer = 0.1f;
                spiralCount++;

                if (spiralCount >= 30)
                {
                    invokeTimer2 = 4f;
                    startInvoke2 = false;
                    rafagasCount = 0;
                }

            }

            invokeTimer2 -= Time.deltaTime;
            if (!startInvoke2 && invokeTimer2 <= 0)
            {

                rafagasCount++;
                invokeTimer2 = 0.4f;
                ShootingOnCicle(15);

                if (rafagasCount >= 5)
                {
                    spiralCount = 30;
                    spiralTimer = 5f;
                    startInvoke2 = true;
                }

            }


        }
        else if (hp >= maxHp * 0.25f && hp < maxHp * 0.50f)
        {
            spiralTimer -= Time.deltaTime;

            if (spiralTimer <= 0 && startInvoke2)
            {

                doubleSpiral();
                spiralTimer = 0.1f;
                spiralCount++;

                if (spiralCount >= 35)
                {
                    invokeTimer2 = 4f;
                    startInvoke2 = false;
                    rafagasCount = 0;
                }

            }

            invokeTimer2 -= Time.deltaTime;
            if (!startInvoke2 && invokeTimer2 <= 0)
            {

                rafagasCount++;
                invokeTimer2 = 0.4f;
                ShootingOnCicle(18);

                if (rafagasCount >= 7)
                {
                    spiralCount = 35;
                    spiralTimer = 5f;
                    startInvoke2 = true;
                }

            }

        }
        else if (hp >= 0f && hp < maxHp * 0.25f)
        {
            spiralTimer -= Time.deltaTime;

            if (spiralTimer <= 0 && startInvoke2)
            {

                quadSpiral();
                spiralTimer = 0.1f;
                spiralCount++;

                if (spiralCount >= 40)
                {
                    invokeTimer2 = 4f;
                    startInvoke2 = false;
                    rafagasCount = 0;
                }

            }

            invokeTimer2 -= Time.deltaTime;
            if (!startInvoke2 && invokeTimer2 <= 0)
            {

                rafagasCount++;
                invokeTimer2 = 0.4f;
                ShootingOnCicle(20);

                if (rafagasCount >= 10)
                {
                    spiralCount = 40;
                    spiralTimer = 5f;
                    startInvoke2 = true;
                }

            }
        }
    }

    void ShootingOnCicle(int _numOfProjectiles) {

        float angleStep = 360f / _numOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < _numOfProjectiles; i++) { 
        
            float bulletDirX = startPoint.x + Mathf.Sin((angle*Mathf.PI)/180 )* radius;
            float bulletDirZ = startPoint.z + Mathf.Cos((angle*Mathf.PI)/180 )* radius;

            Vector3 projectileVector = new Vector3(bulletDirX, 0, bulletDirZ);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject aux = Instantiate(shootPrefab, startPoint, Quaternion.identity);
            aux.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.z);

            angle += angleStep;
        
        
        }
    
    }

    void starShoot()
    {
        
        Vector3 starDir = (fireStar.position - this.transform.position).normalized;
        Vector3 starDir1 = (fireStar1.position - this.transform.position).normalized;
        Vector3 starDir2 = (fireStar2.position - this.transform.position).normalized;
        Vector3 starDir3 = (fireStar3.position - this.transform.position).normalized;
        Vector3 starDir4 = (fireStar4.position - this.transform.position).normalized;
        
        


        GameObject starAux = Instantiate(shootPrefab, gameObject.transform.position + starDir * 1f, Quaternion.identity);
        GameObject starAux1 = Instantiate(shootPrefab, gameObject.transform.position + starDir1 * 1f, Quaternion.identity);
        GameObject starAux2 = Instantiate(shootPrefab, gameObject.transform.position + starDir2 * 1f, Quaternion.identity);
        GameObject starAux3 = Instantiate(shootPrefab, gameObject.transform.position + starDir3 * 1f, Quaternion.identity);
        GameObject starAux4 = Instantiate(shootPrefab, gameObject.transform.position + starDir4 * 1f, Quaternion.identity);
        
        


         Vector3 starForce = starDir * 80;
        Vector3 starForce1 = starDir1 * 80;
        Vector3 starForce2 = starDir2 * 80;
        Vector3 starForce3 = starDir3 * 80;
        Vector3 starForce4 = starDir4 * 80;
        
        


        starAux.GetComponent<Rigidbody>().AddForce(starForce);
        starAux1.GetComponent<Rigidbody>().AddForce(starForce1);
        starAux2.GetComponent<Rigidbody>().AddForce(starForce2);
        starAux3.GetComponent<Rigidbody>().AddForce(starForce3);
        starAux4.GetComponent<Rigidbody>().AddForce(starForce4);
        
        

    }

    void spiralShoot() {


        float bulletDirX = startPoint.x + Mathf.Sin((spiralAngle * Mathf.PI) / 180) * radius;
        float bulletDirZ = startPoint.z + Mathf.Cos((spiralAngle * Mathf.PI) / 180) * radius;

        Vector3 projectileVector = new Vector3(bulletDirX, 0, bulletDirZ);
        Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

        GameObject aux = Instantiate(shootPrefab, startPoint, Quaternion.identity);
        aux.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.z);

        spiralAngle += 10f;




    }

    void doubleSpiral() {

       

        for (int i = 0; i <= 1; i++)
        {

            float bulletDirX = startPoint.x + Mathf.Sin(((spiralAngle + 180 * i) * Mathf.PI) / 180) * radius;
            float bulletDirZ = startPoint.z + Mathf.Cos(((spiralAngle +180 * i) * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(bulletDirX, 0, bulletDirZ);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject aux = Instantiate(shootPrefab, startPoint, Quaternion.identity);
            aux.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.z);

        }
        
        spiralAngle += 10f;

        if (spiralAngle >= 360f) spiralAngle = 0f;

    }

    void quadSpiral()
    {
        for (int i = 0; i <= 3; i++)
        {

            float bulletDirX = startPoint.x + Mathf.Sin(((spiralAngle + 90 * i) * Mathf.PI) / 180) * radius;
            float bulletDirZ = startPoint.z + Mathf.Cos(((spiralAngle + 90 * i) * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(bulletDirX, 0, bulletDirZ);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject aux = Instantiate(shootPrefab, startPoint, Quaternion.identity);
            aux.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.z);

        }

        spiralAngle += 10f;

        if (spiralAngle >= 360f) spiralAngle = 0f;

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
}

