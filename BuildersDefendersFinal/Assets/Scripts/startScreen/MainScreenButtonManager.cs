﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;


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
    public Text gold, username;
    public InputField input;
    AudioSource audioSource;
    public AudioClip[] listAudio;
    public ScrollView ScrollView;
    public Sprite image;
    public Image logro1, logro2, logro3, logro4;
    public Text logroNivel;

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
        gold.text = PlayerPrefs.GetInt("Gold", 0).ToString();

        audioSource = GetComponent<AudioSource>();
        
    }
    public void SetPlayerName()
    {
        string value = input.text;

        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString("PlayerName", value);
        username.text = value;
        AchievementManager.achinstance.onNameChange();
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

        if (PlayerPrefs.GetInt("WonGames", 0) >= 1)
        {
            logro1.sprite = image;
        }
        if (PlayerPrefs.GetInt("WonGames", 0) >= 3)
        {
            logro2.sprite = image;
        }
        if (PlayerPrefs.GetInt("WonGames", 0) >= 10)
        {
            logro3.sprite = image;
        }
        if (PlayerPrefs.GetInt("Name", 0) >= 1)
        {
            logro4.sprite = image;
        }

        logroNivel.text = "Lvl " + PlayerPrefs.GetInt("Level", 1)+ "!";
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

    public void DisplayUpgradePanel1()
    {
        if (UpgradePanelBools[0])
        {
            Cards[0].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Cards[0].transform.GetChild(0).gameObject.SetActive(true);
        }

        UpgradePanelBools[0] = !UpgradePanelBools[0];
    }

    public void DisplayUpgradePanel2()
    {
        if (UpgradePanelBools[1])
        {
            Cards[1].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Cards[1].transform.GetChild(0).gameObject.SetActive(true);
        }

        UpgradePanelBools[1] = !UpgradePanelBools[1];
    }


    public void DisplayUpgradePanel3()
    {
        if (UpgradePanelBools[2])
        {
            Cards[2].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Cards[2].transform.GetChild(0).gameObject.SetActive(true);
        }

        UpgradePanelBools[2] = !UpgradePanelBools[2];
    }


    public void DisplayUpgradePanel4()
    {
        if (UpgradePanelBools[3])
        {
            Cards[3].transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Cards[3].transform.GetChild(0).gameObject.SetActive(true);
        }

        UpgradePanelBools[3] = !UpgradePanelBools[3];
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
