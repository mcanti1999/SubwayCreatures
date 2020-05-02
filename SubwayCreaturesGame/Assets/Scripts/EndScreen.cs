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
        LoadHighScore();
    }
    //sets highscore and sets the score texts
    void LoadHighScore()
    {
        if (PlayerPrefs.GetFloat("CurrentScore") < PlayerPrefs.GetFloat("HighScore") || PlayerPrefs.GetFloat("HighScore") == 0f)
        {
            PlayerPrefs.SetFloat("HighScore",PlayerPrefs.GetFloat("CurrentScore"));
        }

        highScore.text = Clock.Instance.FormatTime(PlayerPrefs.GetFloat("HighScore"));
        currentScore.text = Clock.Instance.FormatTime(PlayerPrefs.GetFloat("CurrentScore"));
    }
    
}
