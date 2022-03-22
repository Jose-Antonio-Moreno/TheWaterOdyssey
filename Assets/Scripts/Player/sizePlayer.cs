using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizePlayer : MonoBehaviour
{
    public GameObject player;

    public int life;

    public bool changed;
    // Start is called before the first frame update
    void Start()
    {        
        life = 3;
        changed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 5 && !changed)
        {
            player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            changed = true;
        }
        if (life == 4 && !changed)
        {
            player.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            changed = true;
        }
        if (life == 3 && !changed)
        {
            player.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            changed = true;
        }
        if (life == 2 && !changed)
        {
            player.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            changed = true;
        }
        if (life == 1 && !changed)
        {
            player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            changed = true;
        }
        if (life <=0)
        {
            Death();
        }

    }
    private void Death()
    {

        Destroy(this.gameObject);
    }
}
