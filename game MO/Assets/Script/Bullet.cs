using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "Tank")
       {
            
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.LookRotation(Vector2.up));
            Destroy(effect, 0.1f);
            Destroy(gameObject);
       }
    }

}
