using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BigDropController : MonoBehaviour
{
    [SerializeField] public Transform[] fireStar;
    [SerializeField] public GameObject bubblePrefab;
    public bool hasExploded = false;

    CinemachineImpulseSource impulse;

    public float destroyTime;
    bool hasAbility;
    public PhysicMaterial bouncines;
    public Material poisonColor;

    public ParticleSystem hitParticle;
    public float damage;

    bool isBouncy = false;

    //public bool isBigDrop = false;

    private void Start()
    {
        destroyTime = 1f;
        impulse = transform.GetComponent<CinemachineImpulseSource>();

        Invoke("des", destroyTime + Random.Range(-0.1F, 0.2F));
    }
    private void Awake()
    {
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.BOUNCY, out hasAbility);
        if (hasAbility)
        {
            transform.GetChild(0).GetComponent<SphereCollider>().material = bouncines;
            destroyTime = 5;
            isBouncy = true;
        }
        else { destroyTime = 0.75f; }
        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.BIGBUBBLE, out hasAbility);
        if (hasAbility)
        {
            transform.localScale *= 1.5f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isBouncy && !collision.gameObject.CompareTag("Bullet"))
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
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.POISON, out hasAbility);
            if (hasAbility)
            {
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                Skill_Interface skill = other.gameObject.GetComponent<SkillBehaviours>();
                skill.ActivatePoison();
            }
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.ICE, out hasAbility);
            if (hasAbility)
            {
                //gameObject.GetComponent<Renderer>().material.color = Color.green;
                Skill_Interface skill = other.gameObject.GetComponent<SkillBehaviours>();
                skill.ActivateIce();
            }
            Invoke("des", destroyTime);
        }

        GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.SHIELDBUBBLE, out hasAbility);
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
            GameObject.Find("Armature").GetComponent<SkillManager>().DSkills.TryGetValue(EAbilities.POISON, out hasAbility);
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
        starShoot();
        Destroy(this.gameObject);
    }
    void starShoot()
    {
        for (int i = 0; i < fireStar.Length; i++) {
            Vector3 starDir = (fireStar[i].position - this.transform.position).normalized;
            GameObject starAux = Instantiate(bubblePrefab, gameObject.transform.position + starDir * 1f, Quaternion.identity);
            Vector3 starForce = starDir * 80;
            starAux.GetComponent<Rigidbody>().AddForce(starForce);
        }
      

    }
}
