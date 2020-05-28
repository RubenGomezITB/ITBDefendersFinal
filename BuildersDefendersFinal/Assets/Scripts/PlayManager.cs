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
    public Text Text;
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

        if (nexusMaster.life <= 0 && PhotonNetwork.IsMasterClient)
        {
            RoundCounter.instance.clientRoundsWin++;
            load = true;
        }
        else if (nexusClient.life <= 0 && PhotonNetwork.IsMasterClient)
        {
            RoundCounter.instance.hostRoundsWin++;
            load = true;
        }

        if (load)
        {
            PhotonNetwork.LoadLevel(1);
        }
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