using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;



public class Pemain : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    
    public GameObject ledakanEffect;
    Rigidbody2D rb;
    PhotonView PV;
    PlayerManager playerManager;

    // Start is called before the first frame update

     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PV = GetComponent<PhotonView>();
        playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
    }
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>(); 
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void TakeDamage(int damage)
    {
     
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        { 
            TakeDamage(8);
        }
        if (currentHealth <= 0)
        {

            Destroy(gameObject);
            GameObject effect = Instantiate(ledakanEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            SceneManager.LoadScene("GameOver");
        }
    }

    void Destroy()
    {
        playerManager.Die();
    }

    
}

