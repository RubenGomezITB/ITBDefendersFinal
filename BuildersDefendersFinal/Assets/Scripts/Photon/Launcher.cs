﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    private byte maxPlayers = 2;
    private bool connected = false;
    private bool isLoading = false;
    public Text playerName;


    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        Connect();
    }

  

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
        }
        else
        {
            //Conexión con el servidor maestro de pun
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("conectado a master bro");
        playerName.text = PlayerPrefs.GetString("PlayerName", "");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(cause);
    }

    public void ConnectToGame()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No hay salas disponibles");
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayers});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entrando en sala bro");
        connected = true;
  
    }
    
    
}