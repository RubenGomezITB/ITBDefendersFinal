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
                Instantiate(camaraHosted);
            }
            else
            {
                Instantiate(camaraClient);
            }

            playing = true;
            isLoading = false;
        }

        if (scene.buildIndex == 2)
        {
            PhotonNetwork.LoadLevel(1);
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
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient && isLoading == false && currentScene.name == "startScene")
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


    public override void OnPlayerLeftRoom(Player other)
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
        playing = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Comprovar si hay jugadores en la sala. Al ser android, al cerrar el juego no desconecta de inmediato, asi que da error si no se hace así
        if (playing && PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            PhotonNetwork.LeaveRoom();
            playing = false;
        }

        if (PhotonNetwork.IsMasterClient && currentScene.name == "startScene" && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            LoadLevel();
        }
    }
}
