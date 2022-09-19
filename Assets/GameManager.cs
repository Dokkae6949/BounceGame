using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public int deactivationAmount = 0;
    public GameObject player;
    public GameObject pauseMenu;
    GameObject pauseInst;

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        StartCoroutine(nextScene());
        
        if(Mathf.Abs(player.transform.position.x) > 30 || Mathf.Abs(player.transform.position.y) > 15 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator nextScene()
    {
        if (deactivationAmount == obstacles.Length)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            deactivationAmount = 0;
        }
    }
}
