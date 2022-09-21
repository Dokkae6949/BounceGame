using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public int deactivationAmount = 0;
    public GameObject player;
    public GameObject pauseMenu;
    GameObject pauseInst;
    public bool canDie = true;

    public bool isTimerPaused = true;
    float currentTime;

    private void Start()
    {
        isTimerPaused = false;
        transform.position = Vector3.zero;
        canDie = true;
        currentTime = 0;
    }

    private void Update()
    {

        if(!isTimerPaused)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        
        if(Convert.ToInt32(time.Seconds * time.Milliseconds) < PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 50000))
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, Convert.ToInt32(time.Milliseconds * time.Seconds));
        }

        Debug.Log(Convert.ToInt32(time.Milliseconds * time.Seconds));


        StartCoroutine(nextScene());


        if(deactivationAmount != obstacles.Length)
        {
            canDie = true;
        }
        else if(deactivationAmount == obstacles.Length)
        {
            canDie = false;
        }

        if(Mathf.Abs(player.transform.position.x) > 21 || Mathf.Abs(player.transform.position.y) > 12 )
        {
            if(canDie)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                StartCoroutine(nextScene());
            }
        }
    }

    IEnumerator nextScene()
    {
        if (deactivationAmount == obstacles.Length)
        {
            isTimerPaused = true;
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            deactivationAmount = 0;
        }
    }
}
