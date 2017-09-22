using UnityEngine;
using System.Collections;

public class CharacterData : MonoBehaviour {
    private int health, damage, armor, energy, power, propertyPoint, money, experience, level, mapPassed;
    private int[] inventory;
    private int[] expOfLevel = {0,
                                50,
                                100,
                                200,
                                360,
                                580,
                                870,
                                1235,
                                1685,
                                2225,
                                2855,
                                3585,
                                4435,
                                5430,
                                6600,
                                7975,
                                9590,
                                11480,
                                13685,
                                16245,
                                19205,
                                22615,
                                26525,
                                30990,
                                36070,
                                41830,
                                48340,
                                55675,
                                63915,
                                73145,
                                83455,
                                94940,
                                107700,
                                121840,
                                137470,
                                154705,
                                173665,
                                194475,
                                217265,
                                242170,
                                269330,
                                298890,
                                331000,
                                365815,
                                403495,
                                444205,
                                488115,
                                535400,
                                586240,
                                640820,
                                699330,
                                761965,
                                828925,
                                900415,
                                976645,
                                1057830,
                                1144190,
                                1235950,
                                1333340,
                                1436595,
                                1545955,
                                1661665,
                                1783975,
                                1913140,
                                2049420,
                                2193080,
                                2344390,
                                2503625,
                                2671065,
                                2846995,
                                3031705,
                                3225490,
                                3428650,
                                3641490,
                                3864320,
                                4097455,
                                4341215,
                                4595925,
                                4861915,
                                5139520,
                                5429080,
                                5730940,
                                6045450,
                                6372965,
                                6713845,
                                7068455,
                                7437165,
                                7820350,
                                8218390,
                                8631670,
                                9060580,
                                9505515,
                                9966875,
                                10445065,
                                10940495,
                                11453580,
                                11984740,
                                12534400,
                                13102990,
                                13690945,
                                14298705,
                                };
    private float speed;
    public static GameObject isExitGameObject;
    // Use characterData for initialization
    void Awake () {
        DontDestroyOnLoad(gameObject);
        if (isExitGameObject == null)
            isExitGameObject = gameObject;
        else
            if (isExitGameObject != gameObject)
                Destroy(gameObject);

        inventory = new int[10];
        LoadData();
        InvokeRepeating("SaveData", 30, 60);
    }

    // Update is called once per frame

    public void SaveData()
    {
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("damage", damage);
        PlayerPrefs.SetInt("power", power);
        PlayerPrefs.SetInt("armor", armor);
        PlayerPrefs.SetInt("energy", energy);
        PlayerPrefs.SetInt("propertyPoint", propertyPoint);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("experience", experience);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("mapPassed", mapPassed);

        PlayerPrefs.SetFloat("speed", speed);

        //Save Item
        PlayerPrefs.SetInt("inventory1", inventory[1]);
        PlayerPrefs.SetInt("inventory2", inventory[2]);
        PlayerPrefs.SetInt("inventory3", inventory[3]);
        PlayerPrefs.SetInt("inventory4", inventory[4]);
        PlayerPrefs.SetInt("inventory5", inventory[5]);
        PlayerPrefs.SetInt("inventory6", inventory[6]);
        PlayerPrefs.SetInt("inventory7", inventory[7]);
        PlayerPrefs.SetInt("inventory8", inventory[8]);
        PlayerPrefs.SetInt("inventory9", inventory[9]);
        print("Game Have Been Saved");
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetInt("health");
            damage = PlayerPrefs.GetInt("damage");
            power = PlayerPrefs.GetInt("power");
            armor = PlayerPrefs.GetInt("armor");
            energy = PlayerPrefs.GetInt("energy");
            propertyPoint = PlayerPrefs.GetInt("propertyPoint");
            money = PlayerPrefs.GetInt("money");
            experience = PlayerPrefs.GetInt("experience");
            level = PlayerPrefs.GetInt("level");
            mapPassed = PlayerPrefs.GetInt("mapPassed");
            speed = PlayerPrefs.GetFloat("speed");

            //Load inventory
            inventory[1] = PlayerPrefs.GetInt("inventory1");
            inventory[2] = PlayerPrefs.GetInt("inventory2");
            inventory[3] = PlayerPrefs.GetInt("inventory3");
            inventory[4] = PlayerPrefs.GetInt("inventory4");
            inventory[5] = PlayerPrefs.GetInt("inventory5");
            inventory[6] = PlayerPrefs.GetInt("inventory6");
            inventory[7] = PlayerPrefs.GetInt("inventory7");
            inventory[8] = PlayerPrefs.GetInt("inventory8");
            inventory[9] = PlayerPrefs.GetInt("inventory9");

        }
        else
        {
            /*
            health = 100;
            damage = 10;
            power = 10;
            armor = 0;
            energy = 100;
            propertyPoint = 0;
            money = 0;
            experience = 0;
            level = 1;
            mapPassed = 1;
            speed = 1;
            */
            health = 10000;
            damage = 40;
            power = 10;
            armor = 0;
            energy = 10000;
            propertyPoint = 0;
            money = 0;
            experience = 0;
            level = 1;
            mapPassed = 1;
            speed = 3;

            inventory[1] = 5;
            inventory[2] = 5;
            inventory[3] = 30;
            inventory[4] = 1;
            inventory[5] = 1;
            inventory[6] = 1;
            inventory[7] = 1;
            inventory[8] = 1;
            inventory[9] = 1;

        }
    }

    public int getHealth()
    {
        return health;
    }

    public int getDamage()
    {
        return damage;
    }

    public int getArmor()
    {
        return armor;
    }

    public int getPower()
    {
        return power;
    }

    public int getEnergy()
    {
        return energy;
    }


    public int getPropertyPoint()
    {
        return propertyPoint;
    }

    public int getMoney()
    {
        return money;
    }

    public int getExperience()
    {
        return experience;
    }

    public int getLevel()
    {
        return level;
    }

    public int getMapPassed()
    {
        return mapPassed;
    }

    public float getSpeed()
    {
        return speed;
    }

    public int getInventory(int itemID)
    {
        return inventory[itemID];
    }

    public int getExpOfLevel(int level)
    {
        return expOfLevel[level];
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public void setPower(int power)
    {
        this.power = power;
    }

    public void setArmor(int armor)
    {
        this.armor = armor;
    }

    public void setEnergy(int energy)
    {
        this.energy = energy;
    }


    public void setPropertyPoint(int propertyPoint)
    {
        this.propertyPoint = propertyPoint;
    }

    public void setMoney(int money)
    {
        this.money = money;
    }

    public void setExperience(int experience)
    {
        this.experience = experience;
    }

    public void setLevel(int level)
    {
        this.level = level;
    }

    public void setMapPassed(int map)
    {
        this.mapPassed = map;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setInventory(int itemID, int value)
    {
        this.inventory[itemID] = value;
    }
}
