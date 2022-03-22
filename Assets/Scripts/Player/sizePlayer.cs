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
            player.transform.localScale = new Vector3(140f, 140f, 140f);
            changed = true;
        }
        if (life == 4 && !changed)
        {
            player.transform.localScale = new Vector3(120f, 120f, 120f);
            changed = true;
        }
        if (life == 3 && !changed)
        {
            player.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
            changed = true;
        }
        if (life == 2 && !changed)
        {
            player.transform.localScale = new Vector3(80f, 80f, 80f);
            changed = true;
        }
        if (life == 1 && !changed)
        {
            player.transform.localScale = new Vector3(60f, 60f, 60f);
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
