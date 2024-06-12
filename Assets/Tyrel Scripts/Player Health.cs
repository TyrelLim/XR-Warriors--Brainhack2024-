using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Bar")]
    public GameObject HealthTextObj;
    public GameObject ShieldTextObj;
    public Text HealthText;
    public Text ShieldText;
    public Image HealthBar;
    public Image ShieldBar;

    public Animator DeathScreen;
    public GameObject HoldAtoReset;
    bool Dead = false;
    [Header("Stat Points")]
    public float TotalHealth = 50f;
    public float TotalShield = 50f;
    public float Health;
    [SerializeField] float Shield;
    string HealthString;
    string ShieldString;

    [Header("Consumables")]
    public int HealthPotion = 2;
    public int ShieldBattery = 2;

    public GameObject Healingtxt;
    public GameObject Shieldtxt;

    public Text Potion;
    public Text Battery;

    bool Recovering;



    void Start()
    {
        Health = TotalHealth;
        Shield = TotalShield;        
        HealthText = HealthText.GetComponent<Text>();
        ShieldText = ShieldText.GetComponent<Text>();
        Potion = Potion.GetComponent<Text>();
        Battery = Battery.GetComponent<Text>();

    }
    void Update()
    {
        Health = Mathf.Clamp(Health,0 ,TotalHealth);
        Shield = Mathf.Clamp(Shield,0 ,TotalShield);

        HealthBar.fillAmount = Health/TotalHealth;
        ShieldBar.fillAmount = Shield/TotalShield;
        HealthString = Health.ToString();
        ShieldString = Shield.ToString();
        Potion.text = HealthPotion.ToString();
        Battery.text = ShieldBattery.ToString();

        HealthText.text = HealthString;
        ShieldText.text = ShieldString;
        if(Shield > 0)
        {
            HealthTextObj.SetActive(false);
            ShieldTextObj.SetActive(true);
        }
        else
        {
            HealthTextObj.SetActive(true);
            ShieldTextObj.SetActive(false);
        }

        if(Health <= 0 && !Dead)
        {
            DeathScreen.SetTrigger("FadeOut");
            HoldAtoReset.SetActive(true);
            Dead = true;
        }

        if(Input.GetButtonDown("X") && HealthPotion != 0 && !Recovering && Health < 50)
        {
            Recovering = true;
            Healingtxt.SetActive(true);
            StartCoroutine(HealthUp());
        }

        if(Input.GetButtonDown("Y") && ShieldBattery != 0 && !Recovering && Shield < 50)
        {
            Recovering = true;
            Shieldtxt.SetActive(true);
            StartCoroutine(ShieldUp());
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("BadBullet"))
        {
            Debug.Log("Player Hit");
            if(Shield > 0)
            {
                Shield -= 5;
            }
            else
            {
                Health -= 5;
            }
        }
    }

    IEnumerator HealthUp()
    {
        
        HealthPotion -= 1;
        for(int i = 0; i < 25; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Health += 1;
            if(Health == 50)
            {
                Recovering = false;
                Healingtxt.SetActive(false);
                break;
            }
        }
        Healingtxt.SetActive(false);
        Recovering = false;
    }

    IEnumerator ShieldUp()
    {
        ShieldBattery -= 1;
        for(int i = 0; i < 25; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Shield += 1;
            if(Shield == 50)
            {
                Recovering = false;
                Shieldtxt.SetActive(false);
                break;
            }
        }
        Shieldtxt.SetActive(false);
        Recovering = false;
    }
}
