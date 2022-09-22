using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SpeedrunTimer : MonoBehaviour
{
    public bool isTimerPaused = true;
    float currentTime;
    TextMeshProUGUI timer;

    public string roundTime;

    string speedrunTimer;

    public char[] arrayTime;

    string seconds;
    string minutes;

    private void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        isTimerPaused = false;
        currentTime = 0;
    }

    private void Update()
    {

        if (!isTimerPaused)
        {
            currentTime += Time.deltaTime;
        }
        if(Convert.ToInt32(seconds) < 10)
        {
            seconds = Convert.ToString("0" + Mathf.Floor(currentTime % 60));
        } else
        {
            seconds = Convert.ToString(Mathf.Floor(currentTime % 60));
        }

        if (Convert.ToInt32(minutes) < 10)
        {
            minutes = Convert.ToString("0" + Mathf.Floor(currentTime / 60));
        }
        else
        {
            minutes = Convert.ToString(Mathf.Floor(currentTime / 60));
        }



        roundTime = minutes + ":" + seconds + ":" + Convert.ToString(currentTime - Mathf.Floor(currentTime)).Remove(0, 2);
        speedrunTimer = "";
        arrayTime = roundTime.ToCharArray();
        
        for(int i = 0; i < 9; i++)
        {
            speedrunTimer += arrayTime[i];
        }

        timer.text = speedrunTimer;
    }

    public void StopTimer()
    {
        isTimerPaused = true;
        if (currentTime < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name, 50000))
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, currentTime);
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "String", speedrunTimer);
        }
    }
}
