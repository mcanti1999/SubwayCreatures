using System;
using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using Event = StateMachines.Event;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
            
        }
    }
    //Note to myself: if scripts still work while timescale is 0, disable and enable them here 
    private void PauseGame()
    {
       // Time.timeScale = 0;
        StateMachine.Instance.Trigger(Event.EnteredPauseScreen);
        pausePanel.SetActive(true);
    } 
    private void ContinueGame()
    {
       // Time.timeScale = 1;
        pausePanel.SetActive(false);
        StateMachine.Instance.Trigger(Event.ExitedPauseScreen);
    }
}
