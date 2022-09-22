using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonManager : MonoBehaviour
{

    public GameObject levelButton;

    private void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
        }

        for(int i = 1; i < scenes.Length; i++)
        {
            GameObject newLvlBtn = Instantiate(levelButton, Vector3.zero, Quaternion.identity);
            newLvlBtn.name = scenes[i];
            newLvlBtn.transform.parent = gameObject.transform;
            Button goToScene = newLvlBtn.GetComponent<Button>();
            int x = i;
            goToScene.onClick.AddListener(delegate { LoadLevel(x); });
            GameObject LvLText = newLvlBtn.transform.GetChild(0).gameObject;
            GameObject HighScoreText = newLvlBtn.transform.GetChild(1).gameObject;
            TextMeshProUGUI Text = LvLText.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI HighScore = HighScoreText.GetComponent<TextMeshProUGUI>();
            Text.text = scenes[x].Remove(0, 5);
            if(PlayerPrefs.GetString(scenes[x] + "String") == "")
            {
                HighScore.text = "00:00:000";
            } else
            {
                HighScore.text = PlayerPrefs.GetString(scenes[x] + "String");
            }

        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    public void NextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
