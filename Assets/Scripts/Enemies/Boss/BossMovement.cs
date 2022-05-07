using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed, waitTime, startWaitTime;
    public Transform moveSpot;
    public float minX, maxX, minZ, maxZ;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        moveSpot.position = new Vector3(Random.Range(minX, maxX), 1.5f, Random.Range(minZ, maxZ));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpot.position) < 0.2f) {

            if (waitTime <= 0) {

                moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            }
            else
            {

                waitTime -= Time.deltaTime;
            }
        }
    }
}
