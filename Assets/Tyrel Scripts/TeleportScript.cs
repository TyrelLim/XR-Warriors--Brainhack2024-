using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject KeyCard;
    public GameObject GetKeyPanel;
    public GameObject HoldAPanel;
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Shooter"))
        {
            if(KeyCard.activeSelf)
            {
                HoldAPanel.SetActive(true);
            }
            else
            {
                GetKeyPanel.SetActive(true);
            }
        }

    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Shooter"))
        {
            HoldAPanel.SetActive(false);
            GetKeyPanel.SetActive(false);
        }
        
    }
}
