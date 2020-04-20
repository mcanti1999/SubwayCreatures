﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeStart;
    public Text hstimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        hstimer.text = FormatTime(timeStart);
    }
    //changes time format to mm:ss:ms
    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 100;
        fraction = (fraction % 100);
        string timeText = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        return timeText;
    }
}