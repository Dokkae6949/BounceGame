using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject pause;
    public bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
