using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    } 
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
