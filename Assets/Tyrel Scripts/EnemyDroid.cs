using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroid : MonoBehaviour
{
    public GameObject Player;
    public float sightDistance = 10f;
    public float AreaOfSight = 60f;

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
        Invoke("FindPlayer",0.5f);
        Player = GameObject.FindWithTag("HitBox");
    }

    void FindPlayer()
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < sightDistance)
        {
            Vector3 targetDirection = Player.transform.position - transform.position;
            float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            if(angleToPlayer >= -AreaOfSight && angleToPlayer <= AreaOfSight)
            {
                Ray ray = new Ray(transform.position, targetDirection);
                Ray FiringRay = new Ray(transform.position, transform.forward);
                RaycastHit hit = new RaycastHit();
                RaycastHit target = new RaycastHit();
                if(Physics.Raycast(ray,out hit, sightDistance))
                {
                    if(hit.collider.CompareTag("Shooter"))
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2.5f * Time.deltaTime);
                        if(Physics.Raycast(FiringRay,out target, sightDistance))
                        {
                            if(target.collider.CompareTag("Shooter") && readyToShoot)
                            {
                                ShootPlayer();
                            }
                        }
                    }
                }
                Debug.DrawRay(ray.origin, ray.direction * sightDistance);

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
