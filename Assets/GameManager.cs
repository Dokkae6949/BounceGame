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
    public bool canDie = true;

    private void Start()
    {
        transform.position = Vector3.zero;
        canDie = true;
    }

    private void Update()
    {
        StartCoroutine(nextScene());

        Debug.Log(canDie);

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
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            deactivationAmount = 0;
        }
    }
}
