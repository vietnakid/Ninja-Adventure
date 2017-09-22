using UnityEngine;
using System.Collections;

public class AddPoint : MonoBehaviour {
    public CharacterData characterData;
	// Use characterData for initialization
	void Start () {
        characterData = GameObject.Find("MainData").GetComponent<CharacterData>();
	}
	
	// Update is called once per frame

        public void plusHealth(int health)
    {
        characterData.setHealth(characterData.getHealth() + health);
    }

    public void plusDamge(int damage)
    {
        characterData.setDamage(characterData.getDamage() + damage);
    }

    public void plusArmor(int armor)
    {
        characterData.setArmor(characterData.getArmor() + armor);
    }

    public void plusEnergy(int energy)
    {
        characterData.setEnergy(characterData.getEnergy() + energy);
    }

    public void plusPropertyPoint(int propertyPoint)
    {
        characterData.setPropertyPoint(characterData.getPropertyPoint() + propertyPoint);
    }

    public void plusPower(int power)
    {
        characterData.setPower(characterData.getPower() + power);
    }

    public void plusSpeed(float speed)
    {
        characterData.setSpeed(characterData.getSpeed() + speed);
    }

    /*
    public void plusKnife(int knife)
    {
        characterData.plusDamge(damge);
    }

    

    public void plusMoney(int money)
    {
        characterData.money += money;
    }

    public void plusExperience(int experience)
    {
        characterData.experience += experience;
    }

    public void plusLevel(int level)
    {
        characterData.level += level;
    }
    */
}
