using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    public GameObject CapsulePrefab;

    public float bulletForce = 20f;
    public float CapsuleForce = 20f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet =  Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rbB = bullet.GetComponent<Rigidbody2D>();
        rbB.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

        GameObject Capsule = Instantiate(CapsulePrefab, firePoint.position, firePoint.rotation );
        Rigidbody2D rbC = Capsule.GetComponent<Rigidbody2D>();
        rbC.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
