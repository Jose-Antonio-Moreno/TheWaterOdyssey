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

    //Checker
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        hp = 4;
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        Patroling();

        if(hp<= 0)
        {
            Death();
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
        if (Physics.Raycast(walkPoint, -transform.up,2f, Ground))
        {
            walkPointSet = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Bullet"))
        {
            hp--;
            isHit = true;
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
