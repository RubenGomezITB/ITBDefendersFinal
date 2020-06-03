using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public void OnWin()
    {
        PlayerPrefs.SetInt("WonGames", PlayerPrefs.GetInt("WonGames", 0) + 1);
        //Won Games
        if (PlayerPrefs.GetInt("WonGames", 0) == 1)
        {
            //Achievements.Beginner.Unlock();
            Debug.Log("Begg");
        }
        else if (PlayerPrefs.GetInt("WonGames", 0) == 3)
        {
            //Achievements.Amateur.Unlock();
            Debug.Log("Amat");
        }
        else if (PlayerPrefs.GetInt("WonGames", 0) == 10)
        {
            //Achievements.Expert.Unlock();
            Debug.Log("Expert");
        }

        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold", 0) + 100);
        PlayerPrefs.SetInt("Experience", PlayerPrefs.GetInt("Experience", 0) + 100);
        if (PlayerPrefs.GetInt("Experience", 0) == 100)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
            PlayerPrefs.SetInt("Experience", 0);
            //Achievements.Born.Unlock();
        }
    }

    public void OnLose()
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold", 0) + 50);
        PlayerPrefs.SetInt("Experience", PlayerPrefs.GetInt("Experience", 0) + 50);
        if (PlayerPrefs.GetInt("Experience", 0) == 100)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
            PlayerPrefs.SetInt("Experience", 0);
            //Achievements.Born.Unlock();
        }
    }
}