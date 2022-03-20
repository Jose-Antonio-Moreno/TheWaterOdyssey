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
    public float damage;


    private void Start()
    {
        
        impulse = transform.GetComponent<CinemachineImpulseSource>();
        destroyTime = 1;
        
        
    }
    void Update()
    {
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(SkillManager.EAbilities.BOUNCY, out hasAbility);
        if (hasAbility)
        {
            //gameObject.GetComponent<SphereCollider>().material = bouncines;
            GameObject.Find("Collider").GetComponent<SphereCollider>().material = bouncines;
            destroyTime = 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //gameObject.SetActive(false);
        if (other.CompareTag("Enemy"))
        {
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
