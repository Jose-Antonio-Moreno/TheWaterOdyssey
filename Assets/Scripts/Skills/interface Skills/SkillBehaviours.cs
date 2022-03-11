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
                gameObject.GetComponent<EnemyAIShell>().hp -= 0.2f;
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<EnemyAIShell>().poisonParticles, gameObject.GetComponent<EnemyAIShell>().transform.position, transform.rotation);
            }
            else if (gameObject.GetComponent<EnemyAI>())
            {
                gameObject.GetComponent<EnemyAI>().hp -= 0.2f;
                float colorTime = 0.1f;
                var sequence = DOTween.Sequence();
                sequence.Insert(0, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, colorTime));
                sequence.Insert(colorTime, gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, colorTime));
                Instantiate(gameObject.GetComponent<EnemyAI>().posionParticles, gameObject.GetComponent<EnemyAI>().transform.position, transform.rotation);
            }
        }
        poisonCounter = 0;
    }
}
