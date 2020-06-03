using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("Experience",PlayerPrefs.GetInt("Experience", 0));
        // PlayerPrefs.SetInt("Gold",PlayerPrefs.GetInt("Gold", 0));
        // PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level", 0));
        // PlayerPrefs.SetInt("WonGames",PlayerPrefs.GetInt("WonGames", 0));
        // PlayerPrefs.SetInt("Name",PlayerPrefs.GetInt("Name", 0));
    }

    void Update()
    {
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

    //Name is setted(first time in the game)
        if (PlayerPrefs.GetInt("Name", 0) == 1){
            //Achievements.YouHaveAName.Unlock();
        }

    //Experience Level
        if(PlayerPrefs.GetInt("Experience", 0) == 100){
            PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level", 0)+1);
            PlayerPrefs.SetInt("Experience", 0);
            //Achievements.Born.Unlock();
        }
    }

    public void OnWin(){
        PlayerPrefs.SetInt("WonGames",PlayerPrefs.GetInt("WonGames", 0)+1);
        PlayerPrefs.SetInt("Gold",PlayerPrefs.GetInt("Gold", 0)+100);
        PlayerPrefs.SetInt("Experience",PlayerPrefs.GetInt("Experience", 0)+100);
    }

    public void OnLose(){
        PlayerPrefs.SetInt("Gold",PlayerPrefs.GetInt("Gold", 0)+50);
        PlayerPrefs.SetInt("Experience",PlayerPrefs.GetInt("Experience", 0)+50);
    }

    public void OnName(){
        PlayerPrefs.SetInt("Name",1);
    }
}
