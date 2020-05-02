using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public static Clock Instance { get; private set; }

    private float timeStart;
    public Text hstimer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        hstimer.text = FormatTime(timeStart);
    }
    //changes time format to mm:ss:ms
    public string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 100;
        fraction = (fraction % 99);
        string timeText = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        return timeText;
    }

    public float GetCurrentTime()
    {
        return timeStart;
    }

    public void RestartTimer()
    {
        timeStart = 0f;
    }
}
