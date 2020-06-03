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

    public Button PlayButton;
    //public Text playerName, debugText;


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
            PhotonNetwork.GameVersion = gameVersion;
            
            PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = "258c8da4-1e99-49c0-9872-a0bfda278826";
            PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "eu";
            PhotonNetwork.ConnectUsingSettings();
            //debugText.text += "\n Conectando a master";
        }
    }

    public override void OnConnectedToMaster()
    {
        PlayButton.gameObject.SetActive(true);
        Debug.Log("conectado a master bro");
        //debugText.text += "\n Conectado a master";
        //debugText.text += "\n " + PhotonNetwork.CloudRegion;
        playerName.text = PlayerPrefs.GetString("PlayerName", "");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(cause);
    }

    public void ConnectToGame()
    {
        PhotonNetwork.JoinRandomRoom();
        //debugText.text += "\n Entrando en sala";
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No hay salas disponibles");
        //debugText.text += "\n no hay salas";
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayers});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entrando en sala bro");
        connected = true;
  
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        //debugText.text += "\n sala creada";
    }
}