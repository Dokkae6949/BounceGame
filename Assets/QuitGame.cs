using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void QuitButton()
    {
        Debug.Log("WHAT?");
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(0);
    }
}
