using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform MainEnterance, Level2, Level3;
    [SerializeField] Transform DroidPoint;
    [SerializeField] GameObject XROrigin;
    [SerializeField] Camera playerHead;
    [SerializeField] GameObject Droid;
    
    public GameObject Locomotion;
    public int resetViewAngle = 0;
    public Vector3 initialXROriginPosition;

    [Header("Hold A gameobjects")]
    public GameObject HoldAlvl1;
    public GameObject HoldAlvl2;
    public GameObject Keycard;
    bool TpDone = true;
    void Start()
    {
        initialXROriginPosition = XROrigin.transform.position;
    }

    [ContextMenu("StartSpawn")]
    public void StartingSpawn()
    {   
        var rotationAngleY = MainEnterance.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
 
        XROrigin.transform.Rotate(0, rotationAngleY, 0);
 
        var distanceDiff = MainEnterance.position - playerHead.transform.position;
 
        XROrigin.transform.position += distanceDiff;
 
        XROrigin.transform.position = new Vector3(XROrigin.transform.position.x,initialXROriginPosition.y,XROrigin.transform.position.z);
 
        resetViewAngle += 1;
    }

    [ContextMenu("Level 2")]
    public void Level2Spawn()
    {
        var rotationAngleY = Level2.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
 
        XROrigin.transform.Rotate(0, rotationAngleY, 0);
 
        var distanceDiff = Level2.position - playerHead.transform.position;
 
        XROrigin.transform.position += distanceDiff;
 
        XROrigin.transform.position = new Vector3(XROrigin.transform.position.x,initialXROriginPosition.y,XROrigin.transform.position.z);
 
        resetViewAngle += 1;
    }

    [ContextMenu("Level 3")]
    public void Level3Spawn()
    {
        var rotationAngleY = Level3.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
 
        XROrigin.transform.Rotate(0, rotationAngleY, 0);
 
        var distanceDiff = Level3.position - playerHead.transform.position;
 
        XROrigin.transform.position += distanceDiff;
 
        XROrigin.transform.position = new Vector3(XROrigin.transform.position.x,initialXROriginPosition.y,XROrigin.transform.position.z);
 
        resetViewAngle += 1;

        Droid.transform.position = DroidPoint.position;
    }


    void Update()
    {
        if(HoldAlvl1.GetComponent<HoldA>().TpStatus)
        {
            HoldAlvl1.SetActive(false);
            Level2Spawn();
            HoldAlvl1.GetComponent<HoldA>().TpStatus = false;
            foreach (Transform child in Keycard.transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        if(HoldAlvl2.GetComponent<HoldA>().TpStatus)
        {
            HoldAlvl2.SetActive(false);
            Level3Spawn();
            HoldAlvl2.GetComponent<HoldA>().TpStatus = false;
            foreach (Transform child in Keycard.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
 
   

}