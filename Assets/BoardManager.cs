using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class BoardManager : MonoBehaviour
{
    int leaderboardID = 7287;

    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }

    public void SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
        {
            if(response.success)
            {
                Debug.Log("Successfully uploaded score");
                done = true;
                return;
            } else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
    }

}
