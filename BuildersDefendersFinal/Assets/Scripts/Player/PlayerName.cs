using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    const string playerNamePrefKey = "PlayerName";
    public GameObject Players, button, logs, launcher;

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

        PlayerPrefs.SetString(playerNamePrefKey, value);
        PlayerPrefs.SetInt("Name", 1);
    }
}