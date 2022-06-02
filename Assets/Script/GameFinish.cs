using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    public TextMeshProUGUI timeSpentField;
    private TimeSpan timePlaying;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        timePlaying = TimerController.instance.GetLastTimer();
        if(TimerController.instance.GetLastTimer().TotalSeconds > 10)
            scoreManager.AddScore(new Score(timePlaying.ToString("hh':'mm':'ss")));

        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        timeSpentField.text = timePlayingStr;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
