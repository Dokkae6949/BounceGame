using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class GameManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public int deactivationAmount = 0;
    public GameObject player;

    private async void Update()
    {
        if (deactivationAmount == obstacles.Length)
        {
            await Task.Delay(2000);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        if(Mathf.Abs(player.transform.position.x) > 30 || Mathf.Abs(player.transform.position.y) > 15 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
