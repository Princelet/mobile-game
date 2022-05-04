using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotal : MonoBehaviour
{
    public Text ScoreDisplay;
    private int scoreVal = 0;

    public void addScore(int toAdd)
    {
        scoreVal += toAdd;

        ScoreDisplay.text = scoreVal.ToString();

    }


    // Start is called before the first frame update
    void Start()
    {
        ScoreDisplay.text = scoreVal.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
