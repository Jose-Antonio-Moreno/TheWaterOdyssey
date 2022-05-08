using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletScript : MonoBehaviour
{
    CinemachineImpulseSource impulse;
    
    public float destroyTime;
    bool hasAbility;
    public PhysicMaterial bouncines;
    public Material poisonColor;

    public ParticleSystem hitParticle;
    public float damage;

    bool isBouncy = false;

    private void Start()
    {
        destroyTime = 1f;
        impulse = transform.GetComponent<CinemachineImpulseSource>();
        
        Invoke("des", destroyTime+Random.Range(-0.1F,0.2F));
    }
    private void Awake()
    {
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.BOUNCY, out hasAbility);
        if (hasAbility)
        {
            transform.GetChild(0).GetComponent<SphereCollider>().material = bouncines;
            destroyTime = 5;
            isBouncy = true;
        }
        else { destroyTime = 0.75f; }
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.BIGBUBBLE, out hasAbility);
        if (hasAbility) 
        {
            transform.localScale *= 1.5f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!isBouncy && !collision.gameObject.CompareTag("Bullet"))
            des();
    }

    private void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false);
        if (other.CompareTag("Enemy"))
        {
            if (isBouncy) 
            {
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            impulse.GenerateImpulse(1f);
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.POISON, out hasAbility);
            if (hasAbility)
            {
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                Skill_Interface skill = other.gameObject.GetComponent<SkillBehaviours>();
                skill.ActivatePoison();
            }
            Invoke("des", destroyTime);
        }

        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.SHIELDBUBBLE, out hasAbility);
        if (hasAbility) 
        {
            if (other.CompareTag("BulletEnemy"))
            {
                Invoke("des", destroyTime);
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }
        }
        
        if (other.CompareTag("Dummy"))
        {
            if (isBouncy)
            {
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            impulse.GenerateImpulse(1f);
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.POISON, out hasAbility);
            if (hasAbility)
            {
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                Skill_Interface skill = other.gameObject.GetComponent<SkillBehaviours>();
                skill.ActivatePoison();
            }
            Invoke("des", destroyTime);
            
        }
        if (!other.CompareTag("Bullet"))
        {
            Invoke("des", destroyTime);
        }
    }

    private void des()
    {
        Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
