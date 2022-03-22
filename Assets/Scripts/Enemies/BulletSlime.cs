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
    private bool hitted;
    void Start()
    {
        destroyTime = 2f;
        hitted = false;
    }

    private void Update()
    {
        Invoke("des", destroyTime);
        player = GameObject.FindGameObjectWithTag("Player");
        lifePlayer = player.GetComponent<sizePlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            if (!hitted)
            {
                lifePlayer.life--;
                lifePlayer.changed = false;
                hitted = true;
            }
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
        hitted = false;
        Destroy(this.gameObject);
    }
}
