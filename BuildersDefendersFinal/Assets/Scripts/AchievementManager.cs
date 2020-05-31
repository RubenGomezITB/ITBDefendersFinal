using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] public int winGames;

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnGameWin();
        }
    }

    public void OnGameWin()
    {
        winGames += 1;
        CloudVariables.Level +=1;
        Debug.Log(CloudVariables.Level);
        Cloud.Storage.Save();
        
        if (winGames == 1)
        {
            Achievements.Begginer.Unlock();
            Debug.Log("Begg");
        }
        else if (winGames == 3)
        {
            Achievements.Amateur.Unlock();
            Debug.Log("Amat");
        }
        else if (winGames == 10)
        {
            Achievements.Expert.Unlock();
            Debug.Log("Amat");
        }
    }

    public void OnSetAName(){
        Achievements.Name.Unlock();
    }
}