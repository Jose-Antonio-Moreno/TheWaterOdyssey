using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbsorbManager : MonoBehaviour
{

    PlayerControlls controls;

    public SpringJoint[] springs;
    //public ParameterControllerSB parameters;
    int i = 0;

    private void Awake()
    {
        controls = new PlayerControlls();
        controls.Gameplay.Decrease.performed += ctx => Decrease();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Agua"))
        {
            collision.gameObject.SetActive(false);
            //gameObject.GetComponentInParent<Transform>().localScale += collision.transform.localScale/2; 

            gameObject.GetComponent<Rigidbody>().mass += collision.rigidbody.mass;
            //parameters.NewMass += collision.rigidbody.mass;

            gameObject.GetComponentInParent<Transform>().localScale += (collision.rigidbody.mass * new Vector3(1, 1, 1));
            //parameters.NewScale += (collision.rigidbody.mass * new Vector3(1, 1, 1));

            gameObject.GetComponentInParent<Movement_2>().moveForce *= 1.5f;
        }
    }
    void Decrease()
    {
        gameObject.GetComponentInParent<Transform>().localScale = new Vector3(20.0f, 20.0f, 20.0f);
        //parameters.NewScale = new Vector3(0.4f, 0.4f, 0.4f);

        gameObject.GetComponent<Rigidbody>().mass = 15;
        //parameters.NewMass = 2;
    }


    void CheckSize()
    {
        if (gameObject.GetComponent<Rigidbody>().mass >= 59)
        {
            while (i <= springs.Length)
            {
                springs[i].spring = 1000;
                springs[i].damper = 10;
                i++;
            }
            i = 0;
        }
    }
    void Update()
    {
        CheckSize();
        //if (Input.GetKeyDown("e"))
        //{
        //    gameObject.GetComponentInParent<Transform>().localScale -= gameObject.GetComponentInParent<Transform>().localScale / 4;
        //    gameObject.GetComponent<Rigidbody>().mass -= gameObject.GetComponent<Rigidbody>().mass / 4;

        //}
    }


    //REGLES DE 3
    //scale2 = (mass2 * scale1) / mass1;

    //spring2 = (s2 * spring1) / scale1;

    //damper2 = (spring2 * damper1) / spring1;
}