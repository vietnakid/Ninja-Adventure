using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayInventoryInGame : MonoBehaviour
{
    public int itemID;
    private CharacterData characterData;
    // Use this for initialization
    void Start()
    {
        characterData = GameObject.Find("MainData").GetComponent<CharacterData>();
    }

    // Update is called once per frame
    void Update()
    {
        int num = characterData.getInventory(itemID);
        if (num > 0)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "Number of Item")
                {
                    child.gameObject.SetActive(true);
                    child.GetComponent<Text>().text = num.ToString();
                }
                if (child.name == "Image")
                    child.gameObject.SetActive(true);
            }
        }
        else
            foreach (Transform child in transform)
            {
                if (child.name == "Number of Item")
                    child.gameObject.SetActive(false);
                if (child.name == "Image")
                    child.gameObject.SetActive(false);
            }

    }
}
