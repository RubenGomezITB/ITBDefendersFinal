using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Experience",PlayerPrefs.GetInt("Experience", 0));
        PlayerPrefs.SetInt("Gold",PlayerPrefs.GetInt("Gold", 0));
        PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level", 0));
        PlayerPrefs.SetInt("WonGames",PlayerPrefs.GetInt("WonGames", 0));
        PlayerPrefs.SetInt("Name",PlayerPrefs.GetInt("Name", 0));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("Experience", 0));
        if (Input.GetKeyDown("space"))
        {
            OnWin();
            OnLose();
        }

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


        if (PlayerPrefs.GetInt("Name", 0) == 1){
            //Achievements.YouHaveAName.Unlock();
        }

        if(PlayerPrefs.GetInt("Experience", 0) == 100){
            PlayerPrefs.SetInt("Level",1);
            //Achievements.Born.Unlock();
        }
        else if(PlayerPrefs.GetInt("Experience", 0) == 200){
            PlayerPrefs.SetInt("Level",2);
            //Achievements.Grow.Unlock();
        }
        else if(PlayerPrefs.GetInt("Experience", 0) == 300){
            PlayerPrefs.SetInt("Level",3);
            //Achievements.Live.Unlock();
        }
        else if(PlayerPrefs.GetInt("Experience", 0) == 400){
            PlayerPrefs.SetInt("Level",4);
            //Achievements.Work.Unlock();
        }
        else if(PlayerPrefs.GetInt("Experience", 0) == 500){
            PlayerPrefs.SetInt("Level",5);
            //Achievements.Age.Unlock();
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

    // public void OnEnergy(){
    //     if(CloudVariables.Energy < 10){
    //     CloudVariables.Energy += 1;
    //     }
    // }
}
