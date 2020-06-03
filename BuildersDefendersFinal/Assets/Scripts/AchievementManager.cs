using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager achinstance;
    public GameObject canvasAchievement;
    public Text text;
     
    private void Awake()
    {
        if (achinstance == null)
        {
            achinstance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    void Start(){
        canvasAchievement.gameObject.SetActive(false);
    }

    public void OnWin()
    {
        PlayerPrefs.SetInt("WonGames", PlayerPrefs.GetInt("WonGames", 0) + 1);
        //Won Games
        if (PlayerPrefs.GetInt("WonGames", 0) == 1)
        {
            text.text = "Beginner-You won your first game";
            StartCoroutine(showAchievementTime());
        }
        else if (PlayerPrefs.GetInt("WonGames", 0) == 3)
        {
            text.text = "Amateur-You won 3 games";
            StartCoroutine(showAchievementTime());
        }
        else if (PlayerPrefs.GetInt("WonGames", 0) == 10)
        {
            text.text = "Expert-You won 10 games";
            StartCoroutine(showAchievementTime());
        }

        goldExperienceLevel(100,100);
    }

    public void OnLose()
    {
        goldExperienceLevel(50,50);
    }

    public void goldExperienceLevel(int gold,int experience){
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold", 0) + gold);
        PlayerPrefs.SetInt("Experience", PlayerPrefs.GetInt("Experience", 0) + experience);
        if (PlayerPrefs.GetInt("Experience", 0) == 100)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
            PlayerPrefs.SetInt("Experience", 0);
            text.text = "Your new level is: " + PlayerPrefs.GetInt("Level", 0);
            StartCoroutine(showAchievementTime());
        }
    }

    private IEnumerator showAchievementTime()
    {
        canvasAchievement.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        canvasAchievement.gameObject.SetActive(false);
    }
}