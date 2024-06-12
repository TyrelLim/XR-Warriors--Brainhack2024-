using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{   

    float Health = 10;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("GoodBullet") || col.gameObject.CompareTag("Droid"))
        {
            Health -= 10;
        }

        if(col.gameObject.CompareTag("FriendlyBullet"))
        {
            Health -= 5;
        }
    }

    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
