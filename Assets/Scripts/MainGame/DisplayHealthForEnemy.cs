using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHealthForEnemy : MonoBehaviour {
    private int maxHealth;
    private Enemy enemy;
	// Use this for initialization
	void Start () {
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
        maxHealth = enemy.health;
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform child in transform)
        {
            if (child.name == "Slider")
                child.GetComponent<Slider>().value = (float)enemy.health / (float)maxHealth;
            if (child.name == "Health")
                child.GetComponent<Text>().text = enemy.health + "/" + maxHealth;
        }
    }
}
