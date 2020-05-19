using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class introVideoPlayerScript : MonoBehaviour
{
    public double time;
    public double currentTime;
    public GameObject LoadOrNewGame;

    void Start() {
        LoadOrNewGame.SetActive(false);
        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;

        if (currentTime >= time-0.2 || Input.anyKey)
        {
            LoadOrNewGame.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

  
}
