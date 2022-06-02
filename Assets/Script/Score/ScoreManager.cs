using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    private bool isReset = false;
    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderBy(x => x.time);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    private void OnDestroy()
    {
        if (!isReset)
            SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);
        PlayerPrefs.Save();
    }

    public void resetLeaderboard()
    {
        PlayerPrefs.DeleteKey("scores");
        isReset = true;
        SceneManager.LoadScene("MainMenuScene");
    }
}