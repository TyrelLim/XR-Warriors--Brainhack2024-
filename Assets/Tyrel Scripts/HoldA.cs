using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HoldA : MonoBehaviour
{
    public Image progressCircle;
    public GameObject imgCircle;

    public float holdTimer;
    public float totalTime = 1;
    public UnityEvent onPress;
    public bool isheld = true;

    public bool TpStatus = false;
    public bool DroneStatus = false;
    public bool Hacking = false;
    // Update is called once per frame
    void Update()
    {
        if (!isheld && Input.GetButton("A"))
        {
            imgCircle.SetActive(true);
            holdTimer += Time.deltaTime;
            progressCircle.fillAmount = holdTimer / totalTime;
        }

        if (holdTimer > totalTime)
        {
            onPress.Invoke();
            imgCircle.SetActive(false);
            progressCircle.fillAmount = 0;
            holdTimer = 0;
            //isheld = true;
        }
        
        if (Input.GetButtonUp("A"))
        {
            // if button has been let go
            imgCircle.SetActive(false);
            holdTimer = 0;
            progressCircle.fillAmount = 0;

            isheld = false;
        }
    }

    public void EnableTpTolvl2()
    {
        TpStatus = true;
    }

    public void GetDrone()
    {
        DroneStatus = true;
    }

    public void StartHacking()
    {
        Hacking = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
