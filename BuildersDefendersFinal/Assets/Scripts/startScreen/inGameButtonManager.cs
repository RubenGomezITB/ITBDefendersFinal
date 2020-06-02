using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameButtonManager : MonoBehaviour
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

    public void SetSettings() {
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

    private void ActivateSound()
    {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color = new Color32(0, 255, 0, 255);
    }

    private void StopSound()
    {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 0, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color = new Color32(255, 0, 0, 255);
    }

    private void ActivateMusic()
    {
        ColorBlock colors = SettingsBtns[1].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[1].colors = colors;
        SettingsBtns[1].image.color = new Color32(0, 255, 0, 255);
    }

    private void StopMusic()
    {
        ColorBlock colors = SettingsBtns[1].colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 0, 0, 255);
        SettingsBtns[1].colors = colors;
        SettingsBtns[1].image.color = new Color32(255, 0, 0, 255);
    }

    public void SetSound()
    {
        if (soundIsActive)
        {
            StopSound();
        }
        else
        {
            ActivateSound();
        }
        soundIsActive = !soundIsActive;
    }

    public void SetMusic()
    {
        if (musicIsActive)
        {
            StopMusic();
        }
        else
        {
            ActivateMusic();
        }
        musicIsActive = !musicIsActive;
    }

    public void ExitGame() {
        SceneManager.LoadScene("startSceneKleyton", LoadSceneMode.Single);
        SetSettings();
    }
}
