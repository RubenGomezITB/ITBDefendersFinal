using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;
    public GameObject camaraClient, camaraHosted;
    public bool playing = false;
    private Scene currentScene;
    public AudioSource AudioSource;
    public AudioClip[] listAudio;

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

    public void Start()
    {
        AudioSource = GetComponent<AudioSource>();
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
        Debug.Log(scene.name == "StartSceneMaster");
        if (scene.name == "StartSceneMaster")
        {
            AudioSource.clip = listAudio[0];
            if (!AudioSource.isPlaying)
            {
                AudioSource.Play();
            }
        }
        if (scene.name == "PlaySceneMaster")
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Instantiate(camaraHosted);
            }
            else
            {
                Instantiate(camaraClient);
            }

            playing = true;
            isLoading = false;

            AudioSource.clip = listAudio[1];
            if (!AudioSource.isPlaying)
            {
                AudioSource.Play();
            }
        }
        else
        {
            AudioSource.Stop();
        }

    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private bool isLoading = false;

    public void LoadLevel()
    {
        if (isLoading == false && currentScene.name == "StartSceneMaster")
        {
            isLoading = true;
            PhotonNetwork.LoadLevel(1);
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

    private void Update()
    {
        if (playing == false && PhotonNetwork.InRoom)
        {
            
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2 & PhotonNetwork.IsMasterClient)
            {
                LoadLevel();
            }
        }
    }
    }