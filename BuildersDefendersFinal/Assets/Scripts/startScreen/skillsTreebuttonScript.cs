using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class skillsTreebuttonScript : MonoBehaviour
{
    public Button button;
    public float fadeTime;
    public bool displayInfo;
    public string myString;
    // Start is called before the first frame update
    void Start()
    {
        myString = button.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgraded() {
        Debug.Log(button.name);
        ColorBlock colors = button.colors;
        colors.normalColor = Color.green;
        colors.highlightedColor = new Color32(0, 255, 0, 255);
        button.colors = colors;
    }

    

}
