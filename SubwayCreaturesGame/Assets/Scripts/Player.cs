using System;
using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Event = StateMachines.Event;


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
    

    //gets damaged when colliding with Enemy
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
            PlayerPrefs.SetFloat("CurrentScore",Clock.Instance.GetCurrentTime());
            StateMachine.Instance.Trigger(Event.EnteredLooseScreen);
        }
        
    }

    
}
