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
    public Text goldText;
    public GameObject cardScreen;
    private DisplayCardAttributesScript cardScreenScript;
    [SerializeField] public bool cardScreenIsActive;
    
    //... other properties

    // Start is called before the first frame update
    void Start()
    {
        cardScreenScript = cardScreen.transform.GetChild(0).gameObject.GetComponent<DisplayCardAttributesScript>();
        cardImage = GetComponent<Image>();
        UpdateCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeCard()
    {
        int gold = int.Parse(goldText.text);
        int requiredGold = card.nextLvlCard.upgradeGoldCost;

        if (card.nextLvlCard != null && ((gold-requiredGold)>=0))
        {
            goldText.text = (gold - requiredGold).ToString();
            card = card.nextLvlCard;
            UpdateCard();
        }
    }

    public void UpdateCard() {//Actualiza la info de la carta actual
        //UpdateCardScreenCard();
        cardImage.sprite = card.cardArt;
        cardImage.type = Image.Type.Simple;
        life.text = card.Life.ToString();
        attack.text = card.Damage.ToString();

        if (card.nextLvlCard != null)
        {
            level.text = card.lvl.ToString();
        }
        else
        {
            level.text = "MAX";
        }
        
    }
    
    public void UpdateCardScreenCard() {//se actualiza la carta del visor de carta al hacer click en una de las del  deck
        cardScreenScript.card = card;
        cardScreenScript.cardImage.sprite = card.cardArt;
        cardScreenScript.cardImage.type = Image.Type.Simple;
        cardScreenScript.life.text = card.Life.ToString();
        cardScreenScript.attack.text = card.Damage.ToString();
        if (card.nextLvlCard != null)
        {
            cardScreenScript.level.text = card.lvl.ToString();
        }
        else
        {
            cardScreenScript.level.text = "MAX";
        }
    }



    public void SwitchCard(UnitsScriptable _card)
    {
        card = _card;
    }



}
