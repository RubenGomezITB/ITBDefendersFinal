using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScreenButtonManager : MonoBehaviour
{
    public GameObject panelToShow;
    public List<GameObject> ScreensList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (panelToShow != null)
        {
            panelToShow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
   public void playBtn()
   {
       SceneManager.LoadScene("MasterScene", LoadSceneMode.Single);
   }
   */

    public void displayPanel()
    {
        panelToShow.SetActive(true);
    }

    public void hidePanel()
    {
        panelToShow.SetActive(false);
    }
}
