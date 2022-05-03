using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletScript : MonoBehaviour
{
    CinemachineImpulseSource impulse;
    
    float destroyTime;
    bool hasAbility;
    public PhysicMaterial bouncines;
    public Material poisonColor;

    public ParticleSystem hitParticle;
    public float damage;

    bool isBouncy = false;

    private void Start()
    {
        destroyTime = 0.75f;
        impulse = transform.GetComponent<CinemachineImpulseSource>();
    }
    private void Awake()
    {
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.BOUNCY, out hasAbility);
        if (hasAbility)
        {
            transform.GetChild(0).GetComponent<SphereCollider>().material = bouncines;
            destroyTime = 2;
            isBouncy = true;
        }
        else { destroyTime = 0.75f; }
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.BIGBUBBLE, out hasAbility);
        if (hasAbility) 
        {
            transform.localScale *= 1.5f;
        }
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
            else 
            {
                Instantiate(hitParticle, transform.position, Quaternion.identity);
                impulse.GenerateImpulse(1f);
                GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.POISON, out hasAbility);
                if (hasAbility)
                {
                    //gameObject.GetComponent<Renderer>().material.color = Color.green;
                    Skill_Interface skill = other.gameObject.GetComponent<SkillBehaviours>();
                    skill.ActivatePoison();
                }
                Invoke("des", 0.1f);
            }
        }

        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.SHIELDBUBBLE, out hasAbility);
        if (hasAbility) 
        {
            if (other.CompareTag("BulletEnemy"))
            {
                Invoke("des", 0.1f);
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }
        }

        

        if (other.CompareTag("Dummy"))
        {
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            impulse.GenerateImpulse(1f);
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.POISON, out hasAbility);
            if (hasAbility)
            {
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                Skill_Interface skill = other.gameObject.GetComponent<SkillBehaviours>();
                skill.ActivatePoison();
            }
            Invoke("des", 0.1f);
        }

        Invoke("des", destroyTime);
    }

    private void des()
    {
        Destroy(this.gameObject);
    }
}
