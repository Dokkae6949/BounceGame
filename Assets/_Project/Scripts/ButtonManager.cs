using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
            Debug.Log(new Vector3(i * 110, -20, 0));
            newLvlBtn.name = scenes[i];
            newLvlBtn.transform.parent = gameObject.transform;
            Button goToScene = newLvlBtn.GetComponent<Button>();
            int x = i;
            goToScene.onClick.AddListener(delegate { LoadLevel(x); });
            GameObject LvLText = newLvlBtn.transform.GetChild(0).gameObject;
            TextMeshProUGUI Text = LvLText.GetComponent<TextMeshProUGUI>();
            Text.text = scenes[x].Remove(0, 5);

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
