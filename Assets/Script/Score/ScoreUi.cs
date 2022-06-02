using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    public static ScoreUi instance;

    public RowUi rowUi;
    public ScoreManager scoreManager;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Debug.Log("Start");

        var scores = scoreManager.GetHighScores().ToArray();
        int scoreLen = scores.Length;
        if (scoreLen > 5)
            scoreLen = 5;
        for (int i = 0; i < scoreLen; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = (i + 1).ToString();
            row.time.text = scores[i].time.ToString();
        }
    }
}
