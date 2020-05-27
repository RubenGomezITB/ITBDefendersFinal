using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class AchievementManager : MonoBehaviour
{

    [SerializeField]
    public int winGames;
    // Start is called before the first frame update
    void Start()
    {
        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        Cloud.Initialize(false, true);
    }

    public void CloudInitializeComplete(){
        Debug.Log("Initialize");
    }

    public void OnGameWin(){
        winGames += 1;
        if(winGames == 1){
            Achivements.Beginner.Unlock();
            Debug.Log("Begg");
        } else if (winGames == 3){
            Achivements.Amateur.Unlock();
            Debug.Log("Amat");
        } 
    }
}
