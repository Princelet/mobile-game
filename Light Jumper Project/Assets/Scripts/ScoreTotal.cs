using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotal : MonoBehaviour
{
    public Text ScoreDisplay;
    private static int scoreVal = 0;
    public int lanterns = 0;

    public void addScore(int toAdd)
    {
        scoreVal += toAdd;

        ScoreDisplay.text = scoreVal.ToString();
    }

    public void addLantern(int toAddLant)
    {
       lanterns += toAddLant;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreDisplay.text = scoreVal.ToString();
    }
}
