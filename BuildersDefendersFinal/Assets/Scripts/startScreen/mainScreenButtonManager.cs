using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainScreenButtonManager : MonoBehaviour
{
    public GameObject cardScreen;
    public GameObject friendsScreen;
    public GameObject creditsScreen;
    public GameObject changeLogScreen;
    [SerializeField] private bool friendsScreenIsActive;
    [SerializeField] private bool soundIsActive;
    [SerializeField] private bool musicIsActive;
    [SerializeField] private bool chGoBackBtnIsActive;
    [SerializeField] private bool crGoBackBtnIsActive;
    public List<GameObject> ScreensList = new List<GameObject>();
    public List<Button> SettingsBtns = new List<Button>();
    public Launcher launcher;
    public List<Button> Cards = new List<Button>();
    private List<bool> UpgradePanelBools = new List<bool> {false, false, false, false};
    [SerializeField] public bool cardScreenIsActive;
    private DisplayCardAttributesScript cardScreenScript;
    AudioSource audioSource;
    public AudioClip[] listAudio;

    public GameManager gameManager;
    

// Start is called before the first frame update
void Start()
    {
        cardScreenScript = cardScreen.transform.GetChild(0).GetComponent<DisplayCardAttributesScript>();
        friendsScreenIsActive = false;
        soundIsActive = true;
        musicIsActive = true;
        chGoBackBtnIsActive = false;
        crGoBackBtnIsActive = false;

        audioSource = GetComponent<AudioSource>();
    }


    public void SetFriendsScreen()
    {
        if (friendsScreenIsActive)
        {
            this.friendsScreen.SetActive(false);
        }
        else
        {
            this.friendsScreen.SetActive(true);
        }

        friendsScreenIsActive = !friendsScreenIsActive;
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[1];
            audioSource.Play();
        }
    }

    public void DisplayPurchasePanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }

        ScreensList[0].SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
        }
    }

    public void DisplayDeckPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }

        ScreensList[1].SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
        }
    }

    public void DisplayHomePanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }

        ScreensList[2].SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
        }
    }

    public void DisplayAchievementsPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }

        ScreensList[3].SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
        }
    }

    public void DisplaySettingsPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }

        ScreensList[4].SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
        }
    }

    private void ActivateSound()
    {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color = new Color32(0, 255, 0, 255);
        audioSource.gameObject.SetActive(true);
    }

    private void StopSound()
    {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 0, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color = new Color32(255, 0, 0, 255);
        audioSource.gameObject.SetActive(false);
    }

    private void ActivateMusic()
    {
        ColorBlock colors = SettingsBtns[1].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[1].colors = colors;
        SettingsBtns[1].image.color = new Color32(0, 255, 0, 255);
        gameManager.AudioSource.Play();
    }

    private void StopMusic()
    {
        ColorBlock colors = SettingsBtns[1].colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 0, 0, 255);
        SettingsBtns[1].colors = colors;
        SettingsBtns[1].image.color = new Color32(255, 0, 0, 255);
        gameManager.AudioSource.Stop();
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

    public void DisplayCreditsPanel()
    {
        if (crGoBackBtnIsActive)
        {
            creditsScreen.SetActive(false);
        }
        else
        {
            creditsScreen.SetActive(true);
        }
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[1];
            audioSource.Play();
        }

        crGoBackBtnIsActive = !crGoBackBtnIsActive;
    }

    public void DisplayChangeLogPanel()
    {
        if (chGoBackBtnIsActive)
        {
            changeLogScreen.SetActive(false);
        }
        else
        {
            changeLogScreen.SetActive(true);
        }
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[1];
            audioSource.Play();
        }

        chGoBackBtnIsActive = !chGoBackBtnIsActive;
    }

    public void playGame()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[1];
            audioSource.Play();
        }
        launcher.ConnectToGame();
    }

    public void DisplayCardScreen()
    {
        if (cardScreenIsActive)
        {
            cardScreen.SetActive(false);
        }
        else
        {
            cardScreen.SetActive(true);
        }
        if (!audioSource.isPlaying)
        {
            audioSource.clip = listAudio[0];
            audioSource.Play();
        }

        cardScreenIsActive = !cardScreenIsActive;
    }
}
