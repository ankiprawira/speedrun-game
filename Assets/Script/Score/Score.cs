using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Score
{
    public string time;

    public Score(string time)
    {
        this.time = time;
    }
}