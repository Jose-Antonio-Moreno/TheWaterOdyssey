using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    int defaultLife;
    int life;
    int maxLife;
    public bool isDamaging;
    void Start()
    {
        defaultLife = 3;
        maxLife = 5;
        life = 0;
        isDamaging = false;
    }

    void ReceiveDamage() 
    {
        if (life <= 0)
        {
            //IsDeath
        }
        else 
        {
            life -= 1;
            this.transform.localScale = new Vector3(this.transform.localScale.x - 2, this.transform.localScale.y - 2, this.transform.localScale.z - 2);
            isDamaging = true;
        }
        
    }

    void Heal() 
    {
        if (life <= maxLife) 
        {
            life += 1;
            this.transform.localScale = new Vector3(this.transform.localScale.x + 2, this.transform.localScale.y + 2, this.transform.localScale.z + 2);
        }
    }
}
