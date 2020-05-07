using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Range(0.5f, 1.5f)]
    public float fireRate = 1;
    [Range(1, 10)]
    public int damage = 1;
    private float timer;
    //public Transform firePoint;
    // [SerializeField]
    //private ParticalSystem muzzlePartical
    //  [SerializeField]
    //private AudioSource gunFireSource;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer = 0f;
                fireGun2();
            }
        }
    }

    private void fireGun()
    {
        //muzzleParticle.Play();
        //gunFireSource.Play();
          Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void fireGun2()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 2f);
    }
}
