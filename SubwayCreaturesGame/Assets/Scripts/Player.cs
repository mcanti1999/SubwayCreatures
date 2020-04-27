using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(25);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            print("Dead");
            PlayerPrefs.SetFloat("CurrentScore", Timer.GetCurrentTime());
            SceneManager.LoadScene("EndScreen");
            print("like I said, Dead");
        }
        
    }
}
