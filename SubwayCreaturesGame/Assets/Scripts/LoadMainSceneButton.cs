using System.Collections;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Event = StateMachines.Event;

public class LoadMainSceneButton : MonoBehaviour
{
  public void LoadMainScene()
  {
    if (SceneManager.GetActiveScene().name == "EndScreen")
    {
      StateMachine.Instance.Trigger(Event.ExitedEndScreen);
    }
    else if (SceneManager.GetActiveScene().name == "Start")
    {
      StateMachine.Instance.Trigger(Event.EnteredMainGame);
    }
    
    Timer.RestartTimer();
  }

}
