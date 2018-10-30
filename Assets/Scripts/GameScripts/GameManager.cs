using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour {

    public int pointPerStep;
    int steps;
    int comboMultiplier;
    int score;
    int highScore;

    float timer;
    float comboTimer;
    
    string RunTime()
    {
        string time = string.Empty;
        int minutes, seconds = 0;
        minutes = ((int)timer/60)%60;
        seconds = (int)timer % 60;

        time = string.Format("{0:00}:{1:00}", minutes, seconds);
        return time;
    }
}
