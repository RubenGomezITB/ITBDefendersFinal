using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public const int Timer = 180;
    public float timeRemain = 60;
    public bool roundStarted = false, decayBool = false, load = false;
    public GameObject countDownNumbersContainer;
    public Text Text, winLose;
    public UnitLife nexusMaster, nexusClient;
    private bool ended = false, canStart = false;
    public Canvas Canvas;

    public AchievementManager achievementManager;
    public float energyTimer = 0.0f;
    public Slider Slider;
    public Text sliderValue;
    AsyncOperation asyncLoadLevel;


    private void Start()
    {
        StartCoroutine(AnimacionStartRound());
    }

    private IEnumerator AnimacionStartRound()
    {
        countDownNumbersContainer.SetActive(true);
        Debug.Log("CoroutineExample started at " + Time.time.ToString() + "s");
        yield return new WaitForSeconds(3f);
        countDownNumbersContainer.SetActive(false);
        Canvas.gameObject.SetActive(true);
        canStart = true;
        roundStarted = true;
        timeRemain = 180;
        Debug.Log("CoroutineExample ended at " + Time.time.ToString() + "s");  
    }
    

    private void Update()
    {
        if (ended == false && canStart)
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

            energyTimer += Time.deltaTime;
            if (energyTimer >= 10)
            {
                energyTimer = 10;
            }
            Slider.value = energyTimer;
            sliderValue.text = ((int) Mathf.Floor(energyTimer)).ToString();
        }
    }

    public void clientWin()
    {
        ended = true;
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.DestroyAll();
            StartCoroutine(youLose());
        }
        else StartCoroutine(youWin());
    }
    public void hostWin()
    {
        ended = true;
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
    
        winLose.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        PhotonNetwork.LeaveRoom();
        asyncLoadLevel = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone)
        {
            print("Loading the Scene");
            yield return null;
          
        } 
        achievementManager.OnLose();
    }

    private IEnumerator youWin()
    {
        winLose.text = "Ganaste";
    
        winLose.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
        asyncLoadLevel = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone)
        {
            print("Loading the Scene");
            yield return null;
          
        } 
        achievementManager.OnWin();
    }

    private void timerEnded()
    {
        decayBool = true;
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