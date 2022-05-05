using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateBehaviour : MonoBehaviour, UltimateInterface
{
    int massDamage;
    void Start() 
    {
        massDamage = 40;
    }
    public void ActivateBigDrop() 
    {
        //
    }
    public void ActivateDropinomicon() 
    {
        if (gameObject.GetComponent<EnemyAIShell>())
        {
            gameObject.GetComponent<EnemyAIShell>().hp -= massDamage;
            Instantiate(gameObject.GetComponent<EnemyAIShell>().poisonParticles, gameObject.GetComponent<EnemyAIShell>().transform.position, Quaternion.identity);
        }
        else if (gameObject.GetComponent<EnemyAI>())
        {
            gameObject.GetComponent<EnemyAI>().hp -= massDamage;
            Instantiate(gameObject.GetComponent<EnemyAI>().posionParticles, gameObject.GetComponent<EnemyAI>().transform.position, Quaternion.identity);
        }
        else if (gameObject.GetComponent<EnemyAIQuadShoot>()) 
        {
            gameObject.GetComponent<EnemyAIQuadShoot>().hp -= massDamage;
            Instantiate(gameObject.GetComponent<EnemyAIQuadShoot>().posionParticles, gameObject.GetComponent<EnemyAIQuadShoot>().transform.position, Quaternion.identity);
        }
        else if (gameObject.GetComponent<Dummy>()) 
        {
            Instantiate(gameObject.GetComponent<Dummy>().posionParticles, gameObject.GetComponent<Dummy>().transform.position, Quaternion.identity);
        }
        else if (gameObject.GetComponent<YellowSlimeScript>()) 
        {
            gameObject.GetComponent<YellowSlimeScript>().hp -= massDamage;
            Instantiate(gameObject.GetComponent<YellowSlimeScript>().posionParticles, gameObject.GetComponent<YellowSlimeScript>().transform.position, Quaternion.identity);
        }
        else if (gameObject.GetComponent<PurpleTurtle>()) 
        {
            gameObject.GetComponent<PurpleTurtle>().hp -= massDamage;
            Instantiate(gameObject.GetComponent<PurpleTurtle>().poisonParticles, gameObject.GetComponent<PurpleTurtle>().transform.position, Quaternion.identity);
        }
        else if (gameObject.GetComponent<YellowTurtleAI>()) 
        {
            gameObject.GetComponent<YellowTurtleAI>().hp -= massDamage;
            Instantiate(gameObject.GetComponent<YellowTurtleAI>().poisonParticles, gameObject.GetComponent<YellowTurtleAI>().transform.position, Quaternion.identity);
        }
        else if (gameObject.GetComponent<Variant2QuadShoot>()) 
        {
            gameObject.GetComponent<Variant2QuadShoot>().hp -= massDamage;
            Instantiate(gameObject.GetComponent<Variant2QuadShoot>().posionParticles, gameObject.GetComponent<Variant2QuadShoot>().transform.position, Quaternion.identity);
        }

    }
}
