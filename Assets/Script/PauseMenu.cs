using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        TimerController.instance.ResumeTimer();
        gamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        TimerController.instance.EndTimer();
        gamePaused = true;
    }

    public void Retry()
    {
        Debug.Log("Retry...");
    }

    public void BackToMain()
    {
        Debug.Log("BackToMain");
    }
}
