using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviourPun
{
    public int hostRoundsWin = 0, clientRoundsWin = 0;
    public Text youWin, youLose;
    public static RoundCounter instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (hostRoundsWin == 2)
            {
                StartCoroutine(Win());
            }
            else if (clientRoundsWin == 2)
            {
                StartCoroutine(Lose());
            }
        }
        else if (PhotonNetwork.IsMasterClient == false)
        {
            if (hostRoundsWin == 2)
            {
                StartCoroutine(Lose());
            }
            else if (clientRoundsWin == 2)
            {
                StartCoroutine(Win());
            }
        }
    }

    private IEnumerator Lose()
    {
        youLose.text = "Perdiste";
        youLose.enabled = true;
        yield return new WaitForSeconds(3);
        GameManager.instance.playing = false;
        PhotonNetwork.LeaveRoom();
    }

    private IEnumerator Win()
    {
        youWin.enabled = true;
        yield return new WaitForSeconds(3);
        GameManager.instance.playing = false;
        PhotonNetwork.LeaveRoom();
    }
}