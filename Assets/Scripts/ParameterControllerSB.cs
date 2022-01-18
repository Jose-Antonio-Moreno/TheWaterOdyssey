using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterControllerSB : MonoBehaviour
{
    public SpringJoint[] springs;
    int i = 0;

    //Initial Values
    float initialMass;
    float initialDamper;
    float initialSpring;
    Vector3 initialScale;

    //NewValues
    public float NewMass;
    public float NewDamper;
    public float NewSpring;
    public Vector3 NewScale;

    // Start is called before the first frame update
    void Start()
    {
        initialMass = gameObject.GetComponent<Rigidbody>().mass;
        initialDamper = springs[0].damper;
        initialSpring = springs[0].spring;
        initialScale = gameObject.GetComponentInParent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(initialScale);
        Debug.Log(initialMass);
        Debug.Log(initialSpring);
        Debug.Log(initialDamper);
        
        //Scale
        gameObject.GetComponentInParent<Transform>().localScale = (gameObject.GetComponent<Rigidbody>().mass * initialScale) / initialMass;
        NewScale = gameObject.GetComponentInParent<Transform>().localScale;

        //Mass
        //gameObject.GetComponent<Rigidbody>().mass = (gameObject.GetComponentInParent<Transform>().localScale * initialMass) / initialScale;

        //Spring
        while (i <= springs.Length) 
        {
            springs[i].spring = (gameObject.GetComponentInParent<Transform>().localScale.x * initialSpring) / initialScale.x;
            springs[i].spring = (gameObject.GetComponentInParent<Transform>().localScale.y * initialSpring) / initialScale.y;
            springs[i].spring = (gameObject.GetComponentInParent<Transform>().localScale.z * initialSpring) / initialScale.z;
            NewSpring = springs[i].spring;

            //Damper
            springs[i].damper = (springs[i].spring * initialDamper) / initialSpring;
            NewDamper = springs[i].damper;
            i++;
        }
        i = 0;

        //Damper
        //while (i <= springs.Length) 
        //{
            
        //}
    }

    //REGLES DE 3
    //scale2 = (mass2 * scale1) / mass1;

    //spring2 = (s2 * spring1) / scale1;

    //damper2 = (spring2 * damper1) / spring1;
}
