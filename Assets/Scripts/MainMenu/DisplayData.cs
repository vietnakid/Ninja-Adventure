using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayData : MonoBehaviour
{
    private CharacterData characterData;
    private Text text;
    // Use characterData for initialization
    void Start()
    {
        characterData = GameObject.Find("MainData").GetComponent<CharacterData>();
    }

    // Update is called once per frame

    void Update()
    {
        foreach (Transform childUp in transform)
        {
            if (childUp.name == "Character")
                foreach (Transform child in childUp)
                {
                    if (child.name == "Health")
                        child.GetComponent<Text>().text = "Health: " + characterData.getHealth();
                    if (child.name == "Damge")
                        child.GetComponent<Text>().text = "Damage: " + characterData.getDamage();
                    if (child.name == "Armor")
                        child.GetComponent<Text>().text = "Armor: " + characterData.getArmor();
                    if (child.name == "Energy")
                        child.GetComponent<Text>().text = "Energy: " + characterData.getEnergy();
                    if (child.name == "Power")
                        child.GetComponent<Text>().text = "Power: " + characterData.getPower();
                    if (child.name == "Speed")
                        child.GetComponent<Text>().text = "Speed: " + characterData.getSpeed().ToString();

                    if (child.name == "Level")
                        child.GetComponent<Text>().text = "Level: " + characterData.getLevel();

                    if (child.name == "Experience")
                        child.GetComponent<Slider>().value = (float)(characterData.getExperience() - characterData.getExpOfLevel(characterData.getLevel() - 1)) / (float)(characterData.getExpOfLevel(characterData.getLevel()) - characterData.getExpOfLevel(characterData.getLevel() - 1));
                }
            if (childUp.name == "Properties")
                foreach (Transform child in childUp)
                    if (child.name == "propertyPoint")
                    {
                        child.GetComponent<Text>().text = "Point: " + characterData.getPropertyPoint();
                    }
                    else if (child.name == "Image" && (characterData.getPropertyPoint() == 0))
                    {
                        if (characterData.getPropertyPoint() == 0)
                            child.gameObject.SetActive(false);
                        else
                            child.gameObject.SetActive(true);
                    }

        }


    }

}
