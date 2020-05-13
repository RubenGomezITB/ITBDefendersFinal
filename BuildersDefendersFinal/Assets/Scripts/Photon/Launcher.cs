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
    public Text Text;
    private bool connected = false;
    public Text peopleConnected;
    

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        Connect();
    }

    private void Update()
    {
        if (connected)
        {
            peopleConnected.text = PhotonNetwork.CurrentRoom.PlayerCount+ "/"+  maxPlayers;
        }
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
        Text.text += ("\nConectado a master");
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
        Text.text += ("\nNo hay salas disponibles, creando una");
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayers});
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entrando en sala bro");
        Text.text += ("\nConectado a la sala, esperando a otro jugador...");
        connected = true;
    }
    
    
}