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
    AudioSource audioSource;
    public AudioClip[] listAudio;
    PlayManager playManager;
    // Start is called before the first frame update
    void Start()
    {
        settingsIsActive = false;
        soundIsActive = true;
        musicIsActive = true;

        audioSource = GetComponent<AudioSource>();
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
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
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
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[1];
            audioSource.Play();
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
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[1];
            audioSource.Play();
        }
        musicIsActive = !musicIsActive;
    }

    public void ExitGame() {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
        }
        //SetSettings();
        playManager.clientWin();//correcto??
        
    }
}
