using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    const string playerNamePrefKey = "PlayerName";
    public GameObject Players, button, logs, launcher, achievementManager;

    AchievementManager achievement;

    void Start () {
        if (PlayerPrefs.GetString(playerNamePrefKey, "") == "")
        {
            Players.SetActive(false);
            button.SetActive(false);
            logs.SetActive(false);
        }else launcher.SetActive(true); 

        string defaultName = string.Empty;
        InputField _inputField = this.GetComponent<InputField>();
        if (_inputField!=null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }


        PhotonNetwork.NickName =  defaultName;
    }
    
    
    public void SetPlayerName()
    {
        string value = gameObject.GetComponent<InputField>().text;
        // #Important
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = value;
        
        Players.SetActive(true);
        button.SetActive(true);
        logs.SetActive(true);
        launcher.SetActive(true); 

        //AchievementManager.OnSetAName();

        PlayerPrefs.SetString(playerNamePrefKey,value);
    }
    
    
    
}
