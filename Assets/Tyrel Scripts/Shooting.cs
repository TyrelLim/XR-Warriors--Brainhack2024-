using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [Header("GameObjects")]
    public Transform attackPoint;
    public GameObject Bullet;

    [Header("Ammo Capacity")]
    public GameObject Bulletammo;
    public Text Bulletnum;
    public Text MagCount;

    [Header("Projectile settings")]
    public int totalShotsBullet;
    public int Reserve;
    public int mag;
    public float CooldownBullet;
    public float ForceBullet;

    public GameObject ReloadingTxt;
    [Header("Sound Effects")]
    public AudioSource source;
    public AudioClip pewpew;

    // [Header("Sound Effects")]
    // public AudioSource source;
    // public AudioClip pewpew;
    // public AudioClip chickenmp3;
    bool readyToShoot;


    private void Start()
    {
        readyToShoot = true;
        Bulletnum = Bulletnum.GetComponent<Text>();
        MagCount = MagCount.GetComponent<Text>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("R Trig") == true && readyToShoot == true && totalShotsBullet > 0 && !ReloadingTxt.activeSelf)
        {
            Shoot();
        }
        
        if(totalShotsBullet <= 0 && !ReloadingTxt.activeSelf && mag > 0)
        {
            if(mag > 1)
            {
                ReloadingTxt.SetActive(true);
                Invoke("Reload",3f);
            }
            else if(Reserve > 0)
            {
                ReloadingTxt.SetActive(true);
                Invoke("ReloadReserve",1.5f);
            }
            else
            {
                ReloadingTxt.SetActive(true);
                Invoke("Reload",3f);
            }
        }

        if(Input.GetButtonDown("R Grip") && mag > 0 && totalShotsBullet != 0 && totalShotsBullet != 5 && !ReloadingTxt.activeSelf)
        {
            Reserve += totalShotsBullet;
            ReloadingTxt.SetActive(true);
            if(mag > 1)
            {
                
                ReloadingTxt.SetActive(true);
                Invoke("Reload",3f);
                Invoke("magplus1",3f);
            }
            else
            {
                ReloadingTxt.SetActive(true);
                Invoke("ReloadReserve",1.5f);
            }
        }

        if(Reserve > 5)
        {
            Reserve -= 5;
        }
        Bulletnum.text = totalShotsBullet.ToString();
        MagCount.text = mag.ToString();

    }

    private void Shoot()
    {
        readyToShoot = false;

        GameObject projectile = Instantiate(Bullet, attackPoint.position, attackPoint.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = attackPoint.transform.forward * ForceBullet;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        source.PlayOneShot(pewpew);

        totalShotsBullet-= 1;
        Invoke("ResetThrow", CooldownBullet);
    }

    private void ResetThrow()
    {
        readyToShoot = true;
    }

    void Reload()
    {
        mag -= 1;
        totalShotsBullet = 5;
        ReloadingTxt.SetActive(false);
    }

    void ReloadReserve()
    {
        mag -= 1;
        totalShotsBullet = Reserve;
        Reserve = 0;
        ReloadingTxt.SetActive(false);
    }

    void magplus1()
    {
        mag += 1;
    }
}
