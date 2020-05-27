using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCardAttributesScript : MonoBehaviour
{
    public UnitsScriptable card;
    public Image cardImage;
    public Text level;
    public Text life;
    public Text attack;
    //... other properties

    // Start is called before the first frame update
    void Start()
    {
        cardImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        cardImage.sprite = card.cardArt;
        cardImage.type = Image.Type.Simple;
        life.text = card.Life.ToString();
        attack.text = card.Damage.ToString();
        if (card.nextLvlCard != null)
        {
            level.text = card.lvl.ToString();
        }
        else {
            level.text = "MAX";
        }
    }

    public void UpgradeCard()
    {
        if (card.nextLvlCard != null)
        {
            card = card.nextLvlCard;
        }
    }

    public void SwitchCard(UnitsScriptable _card)
    {
            card = _card;
        //... reload in game attributes using the new card
    }
}
