using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDroid : MonoBehaviour
{
    public Transform Player;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public float FollowSpeed;
    public RaycastHit Shot;
    RaycastHit BulletRay;
    public LayerMask LayerMaskPlayer;

    bool AttackMode = false;
    [Header("Shooting GameObjects")]
    public Transform FiringPoint;
    public GameObject Bullet;
    bool readyToShoot = true;
    public int totalShotsBullet = 100;
    public float CooldownBullet = 0.5f;
    public float ForceBullet = 5;
    public AudioSource source;
    public AudioClip pewpew;

    void Update()
    {   
        if(!AttackMode)
        {
            transform.LookAt(Player);
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out Shot ,LayerMaskPlayer))
            {
                TargetDistance = Shot.distance;
                if(TargetDistance >= AllowedDistance)
                {
                    FollowSpeed = 0.035f;
                    transform.position = Vector3.MoveTowards(transform.position, Player.position, FollowSpeed);
                }
                else 
                {
                    transform.rotation = Player.rotation;
                }
            }
        }
        else
        {
            if(Physics.Raycast(transform.position, transform.forward, out BulletRay, 10f))
            {
                if(BulletRay.collider.CompareTag("Droid") && readyToShoot)
                {
                    ShootPlayer();
                }

            }
        }
        AttackMode = false;
        for(float i = 0; i < 90; i += 0.1f)
        {
            Vector3 direction = Quaternion.Euler(0, i, 0) * transform.forward;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, direction, out hit, 20f))
            {
                if(hit.collider.CompareTag("Droid"))
                {
                    Debug.Log("Hit");
                    transform.LookAt(hit.transform);
                    TargetDistance = hit.distance;
                    if(TargetDistance >= AllowedDistance)
                    {
                        FollowSpeed = 0.02f;
                        transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, FollowSpeed);
                        
                    }
                    AttackMode = true;
                }
            }
            direction = Quaternion.Euler(0, -i, 0) * transform.forward;
            RaycastHit hit2;
            if(Physics.Raycast(transform.position, direction, out hit2, 20f))
            {
                if(hit2.collider.CompareTag("Droid"))
                {
                    Debug.Log("Hit");
                    transform.LookAt(hit2.transform);
                    TargetDistance = hit2.distance;
                    if(TargetDistance >= AllowedDistance)
                    {
                        FollowSpeed = 0.02f;
                        transform.position = Vector3.MoveTowards(transform.position, hit2.transform.position, FollowSpeed);
                        
                    }
                    AttackMode = true;
                }
            }
        }
        
    }

    void ShootPlayer()
    {
        readyToShoot = false;

        GameObject projectile = Instantiate(Bullet, FiringPoint.position, FiringPoint.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = FiringPoint.transform.forward * ForceBullet;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        source.PlayOneShot(pewpew);

        totalShotsBullet-= 1;
        Invoke("ResetThrow", CooldownBullet);
    }

    private void ResetThrow()
    {
        readyToShoot = true;
    }
}
