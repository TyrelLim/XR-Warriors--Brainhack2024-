using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public GameObject KeyCard;
    public GameObject[] Droids;
    int RandomDroid;
    bool spawned = false;
    public Vector3 SpawnPoint;
    void Start()
    {
        RandomDroid = Random.Range(0, Droids.Length - 1);
        Debug.Log(RandomDroid);
        SpawnPoint = Droids[RandomDroid].transform.position;
    }
    void Update()
    {
        if(Droids[RandomDroid] == null && !spawned)
        {
            Debug.Log("Keycard Droped");
            Instantiate(KeyCard, SpawnPoint, Quaternion.identity);
            spawned = true;
        }
    }
}
