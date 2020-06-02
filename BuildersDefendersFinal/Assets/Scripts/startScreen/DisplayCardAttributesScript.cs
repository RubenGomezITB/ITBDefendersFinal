using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DisplayCardAttributesScript : MonoBehaviour
{
    public UnitsScriptable card;
    public Image cardImage;
    public Text level;
    public Text cost;
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
        if (cardScreen != null) {
            cardScreenScript = cardScreen.transform.GetChild(0).gameObject.GetComponent<DisplayCardAttributesScript>();
        }
        cardImage = GetComponent<Image>();
        UpdateCard();
    }

    // Update is called once per frame
    void Update()
    {
        //ESTO ES SOLO PARA EL DECK SCREEN
        if (SceneManager.GetActiveScene().name == "StartSceneMaster") {
           UpdateCard();
        }
    }

    public void UpgradeCard()
    {
        int gold = int.Parse(goldText.text);
        int requiredGold = card.nextLvlCard.upgradeGoldCost;

        if (card.nextLvlCard != null && ((gold-requiredGold)>=0))
        {
            goldText.text = (gold - requiredGold).ToString();

            card.Life = card.nextLvlCard.Life;
            card.Damage = card.nextLvlCard.Damage;
            card.Range = card.nextLvlCard.Range;
            card.cost = card.nextLvlCard.cost;
            card.attSpeed = card.nextLvlCard.attSpeed;
            card.movSpeed = card.nextLvlCard.movSpeed;
            card.lvl = card.nextLvlCard.lvl;
            card.cardArt = card.nextLvlCard.cardArt;
            card.nextLvlCard = card.nextLvlCard.nextLvlCard;
            card.upgradeGoldCost = card.nextLvlCard.upgradeGoldCost;

            UpdateCard();
        }
    }

    public void UpdateCard() {//Actualiza la info de la carta actual
        //UpdateCardScreenCard();
        cardImage.sprite = card.cardArt;
        cardImage.type = Image.Type.Simple;
        life.text = card.Life.ToString();
        attack.text = card.Damage.ToString();
        cost.text = card.cost.ToString();
        if (level != null) {
            if (card.nextLvlCard != null)
            {
                level.text = "LVL " + card.lvl.ToString();
            }
            else
            {
                level.text = "LVL MAX";
            }
        }
        
    }
    
    public void UpdateCardScreenCard() {//se actualiza la carta del visor de carta al hacer click en una de las del  deck
        cardScreenScript.card = card;
        if (!cardScreen.activeSelf) {
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
        
    }

    public void SwitchCard(UnitsScriptable _card)
    {
        card = _card;
    }



}
