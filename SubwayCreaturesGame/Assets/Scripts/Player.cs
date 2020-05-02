using System;
using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Event = StateMachines.Event;


public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int coincount; 
    
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
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
            StateMachine.Instance.Trigger(Event.EnteredLooseScreen);
            print("like I said, Dead");
        }
        
    }

    public void IncreaseCCountBy50()
    {
        coincount = coincount + 50;
    }

    public int GetCoinCount()
    {
        return coincount;
    }
}
