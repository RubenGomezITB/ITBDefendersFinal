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
    public float timeRemain;
    public int numberOfRounds = 0;
    public bool roundStarted = false, decayBool = false;
    public Text Text;
    public UnitLife nexusMaster, nexusClient;
    public RoundCounter RoundCounter;

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
            RoundCounter.clientRoundsWin++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (nexusClient.life <= 0 && PhotonNetwork.IsMasterClient)
        {
            RoundCounter.hostRoundsWin++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        numberOfRounds = 1;
        timeRemain = 60;
        roundStarted = true;
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