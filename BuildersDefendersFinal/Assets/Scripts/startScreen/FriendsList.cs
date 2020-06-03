using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friendsList : MonoBehaviour
{
    public Button friendExempleBtn;
    public Image friendsScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(var i = 0; i < 3; i++)
        {
            var button = Instantiate(friendExempleBtn, Vector3.zero, Quaternion.identity) as Button;
            var rectTransform = button.GetComponent<RectTransform>();
            rectTransform.SetParent(friendsScreen.transform);
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            //button.onClick.AddListener(SpawnPlayer);
        }

    }
}
