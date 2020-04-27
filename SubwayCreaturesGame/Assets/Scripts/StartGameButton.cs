using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : StateHandler
{
  public void LoadMainScene()
  {
    Timer.RestartTimer();
    SceneManager.LoadScene("Main");
  }

  public void OnEnter()
  {
    SceneManager.LoadScene("Start");
    throw new System.NotImplementedException();
  }

  public void OnExit()
  {
    throw new System.NotImplementedException();
  }
}
