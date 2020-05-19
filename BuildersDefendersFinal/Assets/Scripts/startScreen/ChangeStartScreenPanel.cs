using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeStartScreenPanel : MonoBehaviour
{
    public Text text;
    public byte fadeSpeed;
    public GameObject imagePanel;
    public GameObject mainMenu;
    private byte opacity = 255;
    private bool fadeGoingDown = true;


    // Start is called before the first frame update
    void Start()
    {
        fadeSpeed = 3;
        mainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (text!=null) {
            fadeInFadeOut();
        }
        if (Input.anyKey) {
            if (imagePanel != null) {
                imagePanel.SetActive(false);
            }
            mainMenu.SetActive(true);
        }

    }

    void fadeInFadeOut() {
        
        if (opacity>0 && fadeGoingDown) {
            opacity -= fadeSpeed;
            text.color = new Color32(253, 155, 0, opacity);
            if (opacity <= 0) {
                fadeGoingDown = false;
            }
        }
        else {
            opacity += fadeSpeed;
            text.color = new Color32(253, 155, 0, opacity);
            if (opacity >= 255)
            {
                fadeGoingDown = true;
            }
        }
        
    }

    void mostrar()
    {

    }
}
