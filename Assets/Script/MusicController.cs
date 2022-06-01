using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private static MusicController musicController;
    private void Awake()
    {
        if(musicController == null)
        {
            musicController = this;
            DontDestroyOnLoad(musicController);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
