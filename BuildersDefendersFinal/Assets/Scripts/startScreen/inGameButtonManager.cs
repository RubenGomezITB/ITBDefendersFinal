using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inGameButtonManager : MonoBehaviour
{
    [SerializeField] private bool settingsIsActive;
    [SerializeField] private bool soundIsActive;
    [SerializeField] private bool musicIsActive;
    public List<GameObject> ScreensList = new List<GameObject>();
    public List<Button> SettingsBtns = new List<Button>();
    // Start is called before the first frame update
    void Start()
    {
        settingsIsActive = false;
        soundIsActive = true;
        musicIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSettings() {
        if (settingsIsActive)
        {
            ScreensList[0].SetActive(false);
        }
        else
        {
            ScreensList[0].SetActive(true);
        }
        settingsIsActive = !settingsIsActive;
    }

    private void activateSound()
    {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color = new Color32(0, 255, 0, 255);
    }

    private void stopSound()
    {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 0, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color = new Color32(255, 0, 0, 255);
    }

    private void activateMusic()
    {
        ColorBlock colors = SettingsBtns[1].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[1].colors = colors;
        SettingsBtns[1].image.color = new Color32(0, 255, 0, 255);
    }

    private void stopMusic()
    {
        ColorBlock colors = SettingsBtns[1].colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 0, 0, 255);
        SettingsBtns[1].colors = colors;
        SettingsBtns[1].image.color = new Color32(255, 0, 0, 255);
    }

    public void setSound()
    {
        if (soundIsActive)
        {
            stopSound();
        }
        else
        {
            activateSound();
        }
        soundIsActive = !soundIsActive;
    }

    public void setMusic()
    {
        if (musicIsActive)
        {
            stopMusic();
        }
        else
        {
            activateMusic();
        }
        musicIsActive = !musicIsActive;
    }

    public void exitGame() {
        SceneManager.LoadScene("startSceneKleyton", LoadSceneMode.Single);
        setSettings();
    }
}
