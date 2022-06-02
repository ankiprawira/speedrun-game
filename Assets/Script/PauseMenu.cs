using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    private readonly PlayerCheckpoint pc;

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
        PlayerMovement.isDisableInput = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        PlayerMovement.isDisableInput = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        TimerController.instance.EndTimer();
        gamePaused = true;
    }

    public void BackToMain()
    {
        PlayerMovement.isDisableInput = false;
        SceneManager.LoadScene("MainMenuScene");
    }
}
