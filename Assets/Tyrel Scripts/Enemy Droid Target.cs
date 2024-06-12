using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroidTarget : MonoBehaviour
{
    public GameObject ControlPanel;
    float Health = 10;
    float time;
    float Timer = 1.5f;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("GoodBullet") || col.gameObject.CompareTag("Droid"))
        {
            Health -= 10;
            ControlPanel = GameObject.FindWithTag("ControlPanel");
            ControlPanel.GetComponent<DroneHacking>().HackTime += 1.5f;
            Destroy(gameObject);
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

        time += Time.deltaTime;
        if(time > Timer)
        {
            Destroy(gameObject);
        }

    }
}

