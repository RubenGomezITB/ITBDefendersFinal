using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;
    public GameObject camara, camaraHosted, camaraClientDefensa, camaraClientAtaque;
    public bool playing = false;
    private Scene currentScene;
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

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene;
        if (scene.name == "PlayScene")
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Instantiate(camara);
                Instantiate(camaraHosted);
            }
            else
            {
                Instantiate(camaraClientDefensa);
                Instantiate(camaraClientAtaque);
            }

            playing = true;
            isLoading = false;
        }
        
    }
    
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private bool isLoading = false;
    public void LoadLevel()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient && isLoading == false && currentScene.name == "MainScene")
        {
            isLoading = true; 
            PhotonNetwork.LoadLevel(1);
        }
    }
    
    public override void OnPlayerEnteredRoom(Player other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            LoadLevel();
        }
    }
    void OnApplicationQuit() 
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene(0);
    }


    public override void OnPlayerLeftRoom(Player other)
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
        playing = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        if (playing && PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            PhotonNetwork.LeaveRoom();
            playing = false;
        }
    }
}
