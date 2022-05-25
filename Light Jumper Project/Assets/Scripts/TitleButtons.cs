using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void ScoreButton()
    {
        /* SceneManager.LoadScene("HighScores"); */
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
