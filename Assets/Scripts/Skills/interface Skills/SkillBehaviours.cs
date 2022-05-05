using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBehaviours : MonoBehaviour, Skill_Interface
{
    int poisonCounter;
    bool havePoison;
    

    public void ActivateDEdge()
    {
        throw new System.NotImplementedException();
    }

    public void ActivateLightStep()
    {
        throw new System.NotImplementedException();
    }

    public void ActivatePoison()
    {
        if (!havePoison) 
        {
            havePoison = true;
            StartCoroutine(Poison());
        }
    }
    public void ActivateBouncy() 
    {

    }

    public void ActivateFireRate() 
    {

    }
    public void ActivateShieldBubble() 
    {

    }

    public void ActivateBigBubble() 
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        poisonCounter = 0;
        havePoison = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Poison() 
    {
        while (poisonCounter < 10) 
        {
            yield return new WaitForSeconds(1);
            if (gameObject.GetComponent<EnemyAIShell>())
            {
                gameObject.GetComponent<EnemyAIShell>().hp -= 2.5f;
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<EnemyAIShell>().poisonParticles, gameObject.GetComponent<EnemyAIShell>().transform.position, Quaternion.identity);
            }
            else if (gameObject.GetComponent<EnemyAI>())
            {
                gameObject.GetComponent<EnemyAI>().hp -= 2.5f;
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<EnemyAI>().posionParticles, gameObject.GetComponent<EnemyAI>().transform.position, Quaternion.identity);
            }
            else if (gameObject.GetComponent<EnemyAIQuadShoot>())
            {
                gameObject.GetComponent<EnemyAIQuadShoot>().hp -= 2.5f;
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<EnemyAIQuadShoot>().posionParticles, gameObject.GetComponent<EnemyAIQuadShoot>().transform.position, Quaternion.identity);
            }
            else if (gameObject.GetComponent<Dummy>())
            {
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<Dummy>().posionParticles, gameObject.GetComponent<Dummy>().transform.position, Quaternion.identity);
            }
            else if (gameObject.GetComponent<YellowSlimeScript>()) 
            {
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<YellowSlimeScript>().posionParticles, gameObject.GetComponent<YellowSlimeScript>().transform.position, Quaternion.identity);
            }
            else if (gameObject.GetComponent<PurpleTurtle>())
            {
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<PurpleTurtle>().poisonParticles, gameObject.GetComponent<PurpleTurtle>().transform.position, Quaternion.identity);
            }
            else if (gameObject.GetComponent<YellowTurtleAI>())
            {
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<YellowTurtleAI>().poisonParticles, gameObject.GetComponent<YellowTurtleAI>().transform.position, Quaternion.identity);
            }
            else if (gameObject.GetComponent<Variant2QuadShoot>())
            {
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<Variant2QuadShoot>().posionParticles, gameObject.GetComponent<Variant2QuadShoot>().transform.position, Quaternion.identity);
            }
        }
        poisonCounter = 0;
    }
}
