using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDroneCompanion : MonoBehaviour
{
    public GameObject HoldA;
    public GameObject Droid;
    public GameObject Door;
    bool done = false;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Shooter") && !done)
        {
            HoldA.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Shooter") && !done)
        {
            HoldA.SetActive(false);
        }
    }

    void Update()
    {
        if(HoldA.GetComponent<HoldA>().DroneStatus)
        {
            Droid.GetComponent<FriendlyDroid>().enabled = true;
            HoldA.SetActive(false);
            done = true;
            HoldA.GetComponent<HoldA>().DroneStatus = false;
            Door.SetActive(false);
        }
    }
}
