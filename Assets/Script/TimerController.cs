using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;
    private bool timerOn;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeCounter.text = "Time: 00 : 00 . 00";
        timerOn = false;
    }

    public void BeginTimer()
    {
        timerOn = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void ResumeTimer()
    {
        timerOn = true;

        StartCoroutine(UpdateTimer());
    }
    public void EndTimer()
    {
        timerOn = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerOn)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm' : 'ss' . 'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
