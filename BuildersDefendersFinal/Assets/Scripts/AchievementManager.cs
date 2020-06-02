using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class AchievementManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cloud.OnInitializeComplete += CloudInitializeComplete;
        Cloud.Initialize(false, true);
    }

    public void CloudInitializeComplete()
    {
        Debug.Log("Initialize");
    }

    private void Update()
    {
        Cloud.Storage.Save();

        if (CloudVariables.WonGames == 1)
        {
            Achievements.Beginner.Unlock();
            Debug.Log("Begg");
        }
        else if (CloudVariables.WonGames == 3)
        {
            Achievements.Amateur.Unlock();
            Debug.Log("Amat");
        }
        else if (CloudVariables.WonGames == 10)
        {
            Achievements.Expert.Unlock();
            Debug.Log("Expert");
        }


        if (CloudVariables.Name){
            Achievements.YouHaveAName.Unlock();
        }

        if(CloudVariables.Experiencie == 100){
            CloudVariables.Level = 1;
            Achievements.Born.Unlock();
        }
        else if(CloudVariables.Experiencie == 200){
            CloudVariables.Level = 2;
            Achievements.Grow.Unlock();
        }
        else if(CloudVariables.Experiencie == 300){
            CloudVariables.Level = 3;
            Achievements.Live.Unlock();
        }
        else if(CloudVariables.Experiencie == 400){
            CloudVariables.Level = 4;
            Achievements.Work.Unlock();
        }
        else if(CloudVariables.Experiencie == 500){
            CloudVariables.Level = 5;
            Achievements.Age.Unlock();
        }
    }

    public void OnWin(){
        CloudVariables.WonGames += 1;
        CloudVariables.Gold += 100;
        CloudVariables.Experiencie += 100;
    }

    public void OnLose(){
        CloudVariables.Gold += 50;
        CloudVariables.Experiencie += 50;
    }
}
