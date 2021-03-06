﻿using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int coinValue = 50;
    //if player hits the coin, then destroy the coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ScoreManager.Instance.ChangeScore(coinValue);
            Destroy(gameObject);
        }
    }
    
    
}
