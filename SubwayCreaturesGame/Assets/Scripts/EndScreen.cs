using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text highScore;
    public Text currentScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("CurrentScore") < PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore",PlayerPrefs.GetFloat("CurrentScore"));
        }

        highScore.text = PlayerPrefs.GetString("HighScore");
        currentScore.text = PlayerPrefs.GetString("CurrentScore");
    }
    
}
