using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Poison_Skill : MonoBehaviour, Skill_Interface
//{

//    public EnemyAI enemyN;
//    public EnemyAIShell enemyS;
//    float poisonTimer;
//    float posionPerSecond;
//    float defaulTimePoison;
//    [SerializeField]
//    ParticleSystem poisonParticles;

//    void Skill_Interface.ActivateSkill() 
//    {
//        if (enemyS.isHit)
//        {
//            poisonTimer = defaulTimePoison;
//            while (poisonTimer >= 0)
//            {
//                if (posionPerSecond <= 0)
//                {
//                    enemyS.hp -= 0.2f;
//                    poisonParticles.Play();
//                    var sequence = DOTween.Sequence();
//                    sequence.Insert(0, enemyS.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.green, defaulTimePoison));
//                    sequence.Insert(defaulTimePoison, enemyS.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.DOColor(Color.white, defaulTimePoison));

//                }
//                else
//                {
//                    posionPerSecond -= Time.deltaTime;
//                }
//                posionPerSecond = 1;
//                poisonTimer--;
//            }
//        }
//        //if (enemyN.isHit)
//        //{
//        //    poisonTimer = defaulTimePoison;
//        //    while (poisonTimer >= 0)
//        //    {
//        //        if (posionPerSecond <= 0)
//        //        {
//        //            enemyN.hp -= 0.2f;
//        //            //poisonParticles.play();
//        //        }
//        //        else
//        //        {
//        //            posionPerSecond -= Time.deltaTime;
//        //        }
//        //        posionPerSecond = 1;
//        //        poisonTimer--;
//        //    }
//        //}
//        poisonParticles.Stop();
//    }
//}
