using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlime : MonoBehaviour
{
    float destroyTime;
    bool hasAbility;
    public ParticleSystem hitBulletSlime;

    private GameObject player;
    private sizePlayer lifePlayer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lifePlayer = player.GetComponent<sizePlayer>();
        destroyTime = 2f;
    }

    void Update()
    {
        Invoke("des", destroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            Instantiate(hitBulletSlime, transform.position, Quaternion.identity);
            Invoke("des", 0.1f);
        }
        if (other.CompareTag("Walls")) 
        {
            Invoke("des", 0.1f);
        }
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.SHIELDBUBBLE, out hasAbility);
        if (hasAbility)
        {
            if (other.CompareTag("Bullet"))
            {
                Instantiate(hitBulletSlime, transform.position, Quaternion.identity);
                Invoke("des", 0.1f);
            }
        }
    }

    public void des()
    {
        lifePlayer.hitted = false;
        Destroy(this.gameObject);
    }
}
