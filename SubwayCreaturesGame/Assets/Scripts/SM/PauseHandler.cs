using System;
using UnityEngine;

namespace StateMachines
{
    public class PauseHandler: StateHandler
    {
        private GameObject pausePanel;

        private void Awake()
        {
            pausePanel = GameObject.Find("PausePanel");
            pausePanel.SetActive(false);
            DontDestroyOnLoad(pausePanel);
        }
        

        // Update is called once per frame
        void Update()
        {
            
            Debug.Log(GameObject.Find("PausePanel"));
            if (Input.GetKeyDown(KeyCode.Escape))
            { 
                if (!pausePanel.activeInHierarchy)
                {
                    ContinueGame();
                }
                else
                {
                    PauseGame();
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
        public override void OnEnter()
        {
            //PauseGame();
        }

        public override void OnExit()
        {
            //ContinueGame();
        }
    }
}