﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
  public void LoadMainScene()
  {
    SceneManager.LoadScene("Main");
  }
}
