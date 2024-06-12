using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooting : MonoBehaviour
{
    public GameObject Droid;
    public Vector3 center;
    public Vector3 size;

    bool Spawning = false;
    void SpawnDroid()
    {
        Vector3 spawnPoint = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), center.y, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(Droid, spawnPoint, Quaternion.identity);
        Spawning = false;
    }

    void Update()
    {
        if(!Spawning)
        {   
            Spawning = true;
            Invoke("SpawnDroid", 1.5f);
        }
        
    }
    
}
