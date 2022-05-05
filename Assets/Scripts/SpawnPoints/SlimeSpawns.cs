using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawns : MonoBehaviour
{
    [SerializeField]
    GameObject[] Slimes;

    //Variables
    public int maxCount;
    int innerCount;
    int number;

    bool isInside = false;

    public Vector3 center;
    public Vector3 size;

    private void Start()
    {
        center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //Spawn();
    }
    void Update()
    {
        if (isInside)
        {
            Spawn();
        }
    }

    void Spawn() 
    {

        if (innerCount >= maxCount)
        {
            Destroy(this);
        }
        else 
        {

            for (int i = 0; i < maxCount; i++)
            {
                number = Random.Range(0, 4);
                Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), this.transform.position.y, Random.Range(-size.z / 2, size.z / 2));
                switch (number)
                {
                    case 0:
                        Instantiate(Slimes[0], pos, Quaternion.identity);
                        innerCount++;
                        break;
                    default:
                        Instantiate(Slimes[1], pos, Quaternion.identity);
                        innerCount++;
                        break;
                }
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
