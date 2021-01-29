using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoSingletonGeneric<ScoreController>
{
    public Text score;
    public Text highScore;
    void Start()
    {
        highScore = GetComponentInChildren<Text>();
        highScore.text ="HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void SetHighScore(int num)
    {
        Debug.Log(num);
        highScore.text = num.ToString();
        if(num > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", num);
            highScore.text = "HighScore: " + num.ToString();
            Debug.Log("High");
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
