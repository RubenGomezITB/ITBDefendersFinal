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
    public List<Button> Cards = new List<Button>();
    private List<bool> UpgradePanelBools = new List<bool> { false, false, false, false };
    [SerializeField] public bool cardScreenIsActive;
    private DisplayCardAttributesScript cardScreenScript;



    // Start is called before the first frame update
    void Start()
    {
        cardScreenScript = cardScreen.transform.GetChild(0).GetComponent<DisplayCardAttributesScript>();
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

    public void SetFriendsScreen() {
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

    public void DisplayPurchasePanel()
    {
        for (var i=0;i<ScreensList.Count;i++) {
            ScreensList[i].SetActive(false);
        }
        ScreensList[0].SetActive(true);
    }

    public void DisplayDeckPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[1].SetActive(true);
    }

    public void DisplayHomePanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[2].SetActive(true);
    }

    public void DisplayAchievementsPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[3].SetActive(true);
    }

    public void DisplaySettingsPanel()
    {
        for (var i = 0; i < ScreensList.Count; i++)
        {
            ScreensList[i].SetActive(false);
        }
        ScreensList[4].SetActive(true);
    }

    private void ActivateSound() {
        ColorBlock colors = SettingsBtns[0].colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        SettingsBtns[0].colors = colors;
        SettingsBtns[0].image.color= new Color32(0, 255, 0, 255);
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
        SettingsBtns[1].image.color = new Color32(255,0, 0, 255);
    }

    public void SetSound() {
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
    
    public void DisplayCreditsPanel() {
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

    public void PlayGame() {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
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
        cardScreenIsActive = !cardScreenIsActive;
    }

}
