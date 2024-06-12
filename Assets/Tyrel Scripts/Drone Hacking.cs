using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneHacking : MonoBehaviour
{
    public GameObject Droid;
    public GameObject HoldA;
    public GameObject TeleportScript;
    public GameObject DroidSpawn;

    public Transform hackPoint;
    public Transform ControlPanel;

    public Image ProgressBar;
    public GameObject ShutDown;
    public GameObject EndGamePanel;

    bool enablemove = false;

    bool BeginHacking = false;
    public float HackTime;
    float TotalTime = 60f;
    void Update()
    {
        if(HoldA.GetComponent<HoldA>().Hacking)
        {
            Droid.GetComponent<FriendlyDroid>().enabled = false;
            Droid.transform.LookAt(ControlPanel);
            
            enablemove = true;
            DroidSpawn.GetComponent<TargetShooting>().enabled = true;
            HoldA.SetActive(false);
            TeleportScript.GetComponent<TeleportScript>().enabled = false;
            HoldA.GetComponent<HoldA>().Hacking = false;
        }

        if(enablemove)
        {
            Droid.transform.position = Vector3.MoveTowards(Droid.transform.position, hackPoint.position, 0.2f);
        }

        if(Droid.transform.position == hackPoint.position)
        {
            HackTime += Time.deltaTime;
        }

        ProgressBar.fillAmount = HackTime/TotalTime;

        if(HackTime >= TotalTime)
        {
            ShutDown.SetActive(false);
            DroidSpawn.GetComponent<TargetShooting>().enabled = false;
            EndGamePanel.SetActive(true);
        }
    }
}
