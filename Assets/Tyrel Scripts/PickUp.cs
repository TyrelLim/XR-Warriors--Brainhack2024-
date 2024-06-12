using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject Keycard;
    void OnTriggerStay(Collider col)
    {
        Debug.Log("PickUp");
        if(col.gameObject.CompareTag("Hand") && Input.GetButton("L Trig") && Input.GetButton("L Grip"))
        {
            Keycard = GameObject.FindWithTag("Keycard");
            foreach (Transform child in Keycard.transform)
            {
                child.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
