using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject RightHand;
    public GameObject Gun;

    bool Started;

    public Text Timetxt;
    public GameObject PlayerHealth;
    float time = 600f;
    float minute;
    float seconds;
    void Start()
    {
        Timetxt = Timetxt.GetComponent<Text>();
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Finger"))
        {
            StartG();
        }
    }

    void StartG()
    {
        RightHand.GetComponent<AnimateHandRight>().shooting = true;
        Gun.SetActive(true);
        StartPanel.SetActive(false);     
        Started = true;   
    }

    void Update()
    {
        minute = Mathf.FloorToInt(time/60);;
        seconds = Mathf.FloorToInt(time % 60);;
        if(Started)
        {
            time -= Time.deltaTime;
        }

        if(time < 0)
        {
            PlayerHealth.GetComponent<PlayerHealth>().Health = 0;
        }
        string timeString = string.Format("{0:00}:{1:00}", minute, seconds);
        Timetxt.text = timeString;

    }
}
