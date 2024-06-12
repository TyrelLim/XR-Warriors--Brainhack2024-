using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool destroy = false;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Destroy bullet");
            destroy = true;
        }
    }
    void Update()
    {
        if(destroy)
        {
            Destroy(gameObject);
        }

    }
}
