using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public const int Timer = 60;
    public float timeRemain = 60;
    public bool roundStarted = false, decayBool = false, load = false;
    public Text Text, winLose;
    public UnitLife nexusMaster, nexusClient;


    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            startRound();
        }
    }

    private void Update()
    {
        Text.text = Mathf.Floor(timeRemain).ToString();
        if (roundStarted && PhotonNetwork.IsMasterClient)
        {
            timeRemain -= Time.deltaTime;


            if (timeRemain <= 0.0f)
            {
                timeRemain = 0;
                timerEnded();
                roundStarted = false;
            }
        }

        if (decayBool && PhotonNetwork.IsMasterClient)
        {
            nexusClient.life--;
            nexusMaster.life--;
        }

        if (nexusMaster.life <= 0)
        {
            clientWin();
        }
        else if (nexusClient.life <= 0)
        {
            hostWin();
        }
    }

    private void clientWin()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.DestroyAll();
            StartCoroutine(youLose());
        }
        else StartCoroutine(youWin());
    }
    private void hostWin()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.DestroyAll();
            StartCoroutine(youWin());
        }
        else  StartCoroutine(youLose());
    }
    private IEnumerator youLose()
    {
        winLose.text = "Perdiste";
        winLose.enabled = true;
        yield return new WaitForSeconds(3);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }

    private IEnumerator youWin()
    {
        winLose.text = "Ganaste";
        winLose.enabled = true;
        yield return new WaitForSeconds(3);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }

    private void timerEnded()
    {
        Decay();
    }

    private void Decay()
    {
        decayBool = true;
    }

    private void startRound()
    {
        roundStarted = true;
        timeRemain = 60;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(timeRemain);
        }
        else
        {
            // Network player, receive data
            timeRemain = (float) stream.ReceiveNext();
        }
    }
}