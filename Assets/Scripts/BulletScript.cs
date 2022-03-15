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
    private void Start()
    {
        impulse = transform.GetComponent<CinemachineImpulseSource>();
        destroyTime = 1;        
    }
    private void Awake()
    {
        //GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.POISON, out hasAbility);
        //if (hasAbility) 
        //{
        //    gameObject.GetComponent<SkinnedMeshRenderer>().material.color = Color.green;
        //}
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.BOUNCY, out hasAbility);
        if (hasAbility)
        {
            //gameObject.GetComponent<SphereCollider>().material = bouncines;
            Debug.Log("Activate");
            GameObject.Find("Collider").GetComponent<SphereCollider>().material = bouncines;
            destroyTime = 5;
        }
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false);
        if (other.CompareTag("Enemy"))
        {
            Instantiate(hitParticle, transform.position, transform.rotation);
            impulse.GenerateImpulse(1f);
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.POISON, out hasAbility);
            if (hasAbility) 
            {
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                Skill_Interface skill = other.gameObject.GetComponent<SkillBehaviours>();
                skill.ActivatePoison();
            }
        }
        Invoke("des", destroyTime);
    }

    private void des()
    {
        Destroy(this.gameObject);
    }
}
