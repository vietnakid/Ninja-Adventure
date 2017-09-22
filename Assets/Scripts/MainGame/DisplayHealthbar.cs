using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHealthbar : MonoBehaviour
{
    private Player player;
    private CharacterData characterData;
    int maxHealth, maxMana;
    void Start()
    {
        characterData = GameObject.Find("MainData").GetComponent<CharacterData>();
        maxHealth = characterData.getHealth();
        maxMana = characterData.getEnergy();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Update is called once per frame

    void Update()
    {
        foreach (Transform childUp in transform)
        {
            if (childUp.name == "Level")
            {
                foreach (Transform child in childUp)
                    if (child.name == "Level")
                        child.GetComponent<Text>().text = "Level " + player.level;
            }
            if (childUp.name == "Experience Bar")
            {
                childUp.GetComponent<Slider>().value = (float)(player.experience - characterData.getExpOfLevel(player.level - 1)) / (float)(characterData.getExpOfLevel(player.level) - characterData.getExpOfLevel(player.level - 1));
            }
            if (childUp.name == "HealthBar")
            {
                foreach (Transform child in childUp)
                {
                    if (child.name == "Damge")
                        child.GetComponent<Text>().text = "Damge " + player.damge;
                    if (child.name == "Power")
                        child.GetComponent<Text>().text = "Power " + player.power;
                    if (child.name == "Armor")
                        child.GetComponent<Text>().text = "Armor " + player.armor;
                    if (child.name == "Speed")
                        child.GetComponent<Text>().text = "Speed " + player.speed;
                    if (child.name == "Health")
                        foreach (Transform childDown in child)
                        {
                            if (childDown.name == "Slider")
                            {
                                childDown.GetComponent<Slider>().value = (float)player.health / (float)maxHealth;
                            }
                            if (childDown.name == "Health")
                                childDown.GetComponent<Text>().text = "Health " + player.health;
                        }
                    if (child.name == "Mana")
                        foreach (Transform childDown in child)
                        {
                            if (childDown.name == "Slider")
                            {
                                childDown.GetComponent<Slider>().value = (float)player.energy / (float)maxMana;
                            }
                            if (childDown.name == "Mana")
                                childDown.GetComponent<Text>().text = "Energy " + player.energy;
                        }
                }
            }
        }

    }
}
