using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class clickThroughUIBug : MonoBehaviour
{
    public void click()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Debug.Log("WHAT?");
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(0);
    }
}
