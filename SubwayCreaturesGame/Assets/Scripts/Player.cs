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
    public Timer timer;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    

    //gets damaged when colliding with Eneny
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(25);
            
        }
    }
    //Take Damage function, when health == 0, then trigger Loose Game State and saves 
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            print("Dead");
            //PlayerPrefs.SetString("CurrentScore",timer.FormatTime(timer.GetCurrentTime()));
            StateMachine.Instance.Trigger(Event.EnteredLooseScreen);
        }
        
    }

    
}
