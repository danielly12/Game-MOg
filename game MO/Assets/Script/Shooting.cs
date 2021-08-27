using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform Fire;
    public GameObject bulletPrefab;


    public float bulletForce = 110f; 

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
     
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, Fire.position, Fire.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Fire.up * bulletForce, ForceMode2D.Impulse);
       
    }

}
