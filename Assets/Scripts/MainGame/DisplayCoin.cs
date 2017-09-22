using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayCoin : MonoBehaviour {
    private CharacterData characterData;
    private Player player;
	// Use this for initialization
	void Start () {
        characterData = GameObject.Find("MainData").GetComponent<CharacterData>();
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        string x;
        if (player != null)
            x = player.money.ToString();
        else
            x = characterData.getMoney().ToString();
        
        this.GetComponent<Text>().text = x;
	}
}
