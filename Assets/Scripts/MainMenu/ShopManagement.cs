using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopManagement : MonoBehaviour {
    private CharacterData characterData;
    [SerializeField]
    private int itemID;
    enum Item
    {
        healthPotion = 1,
        manaPotion = 2,
        knife = 3,
        helmet = 4,
        suit = 5,
        shoes = 6,
        gloves = 7,
        sword = 8
    }

    int[] price;

    int[] priceItem = { 0,
                        200,
                        300,
                        500,
                        800,
                        1200,
                        1700,
                        2300,
                        3000,
                        3800,
                        4700,
                        5700,
                        6800,
                        8000,
                        9300,
                        10700,
                        12200,
                        13800,
                        15500,
                        17300,
                        19200,
                        21200,
                        23300,
                        25500,
                        27800,
                        30200,
                        32700,
                        35300,
                        38000,
                        40800,
                        43700,
                        46700,
                        49800,
                        53000,
                        56300,
                        59700,
                        63200,
                        66800,
                        70500,
                        74300,
                        78200,
                        82200,
                        86300,
                        90500,
                        94800,
                        99200,
                        103700,
                        108300,
                        113000,
                        117800,
                        122700,
                        127700,
                        132800,
                        138000,
                        143300,
                        148700,
                        154200,
                        159800,
                        165500,
                        171300,
                        177200,
                        183200,
                        189300,
                        195500,
                        201800,
                        208200,
                        214700,
                        221300,
                        228000,
                        234800,
                        241700,
                        248700,
                        255800,
                        263000,
                        270300,
                        277700,
                        285200,
                        292800,
                        300500,
                        308300,
                        316200,
                        324200,
                        332300,
                        340500,
                        348800,
                        357200,
                        365700,
                        374300,
                        383000,
                        391800,
                        400700,
                        409700,
                        418800,
                        428000,
                        437300,
                        446700,
                        456200,
                        465800,
                        475500,
                        485300,
                        495200
                        };

    // Use this for initialization
    void Start () {
        characterData = GameObject.Find("MainData").GetComponent<CharacterData>();

        price = new int[10];
        price[(int)Item.healthPotion] = 50;
        price[(int)Item.manaPotion] = 10;
        price[(int)Item.knife] = 10;

        if (gameObject.name == "Price") displayPrice(itemID);
        
    }

    void Update()
    {
        if (gameObject.name == "NumberOfItem") displayNumberOfItem(itemID);
        if (gameObject.name == "Price") displayPrice(itemID);

        //Price update
        for (int i = 4; i < 9; i++)
        {
            price[i] = priceItem[characterData.getInventory(i)];
        }
    }
	
	public void BuyItem(int itemID)
    {
        if (characterData.getMoney() >= price[itemID])
        {
            characterData.setInventory(itemID, characterData.getInventory(itemID) + 1);
            characterData.setMoney(characterData.getMoney() - price[itemID]);
            //Update characterData
            switch (itemID)
            {
                case 4:
                    characterData.setHealth(characterData.getHealth() + 10);
                    characterData.setEnergy(characterData.getEnergy() + 10);
                    break;
                case 5:
                    characterData.setArmor(characterData.getArmor() + 1);
                    break;
                case 6:
                    characterData.setSpeed(characterData.getSpeed() + 0.1f);
                    break;
                case 7:
                    characterData.setPower(characterData.getPower() + 2);
                    break;
                case 8:
                    characterData.setDamage(characterData.getDamage() + 2);
                    break;
            }
        }



    }

    public void displayPrice(int itemID)
    {
        gameObject.GetComponent<Text>().text = price[itemID].ToString();
    }

    public void displayNumberOfItem(int itemID)
    {
        gameObject.GetComponent<Text>().text = characterData.getInventory(itemID).ToString();
    }
}
