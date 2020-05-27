using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainScreenButtonManager : MonoBehaviour
{
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
    public List<Button> Cards = new List<Button>();
    private List<bool> UpgradePanelBools = new List<bool> { false, false, false, false };


    // Start is called before the first frame update
    void Start()
    {
        friendsScreenIsActive = false;
        soundIsActive = true;
        musicIsActive = true;
        chGoBackBtnIsActive = false;
        crGoBackBtnIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFriendsScreen() {
        if (friendsScreenIsActive)
        {
            this.friendsScreen.SetActive(false);
        }
        else
        {
            this.friendsScreen.SetActive(true);
        }
        friendsScreenIsActive = !friendsScreenIsActive;
    }

    public void displayPurchasePanel()
    {
        for (var i=0;i<ScreensList.Count;i++) {
            ScreensList[i].SetActive(false);
        }
        ScreensList[0].SetActive(true);
    }

    public void displayDeckPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[1].SetActive(true);
    }

    public void displayHomePanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[2].SetActive(true);
    }

    public void displayAchievementsPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[3].SetActive(true);
    }

    public void displaySettingsPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[4].SetActive(true);
    }

    private void activateSound() {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color= new Color32(0, 255, 0, 255);
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
        SettingsBtns[1].image.color = new Color32(255,0, 0, 255);
    }

    public void setSound() {
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
    
    public void displayCreditsPanel() {
        if (crGoBackBtnIsActive)
        {
            creditsScreen.SetActive(false);
        }
        else
        {
            creditsScreen.SetActive(true);
        }
        crGoBackBtnIsActive = !crGoBackBtnIsActive;
    }
    public void displayChangeLogPanel()
    {
        if (chGoBackBtnIsActive)
        {
            changeLogScreen.SetActive(false);
        }
        else
        {
            changeLogScreen.SetActive(true);
        }
        chGoBackBtnIsActive = !chGoBackBtnIsActive;
    }

    public void displayUpgradePanel1()
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

    public void displayUpgradePanel2()
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


    public void displayUpgradePanel3()
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


    public void displayUpgradePanel4()
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

    public void playGame() {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

}
