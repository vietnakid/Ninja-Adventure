using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMiniMap : MonoBehaviour {
    
    public GameObject enemyPoint;
    
    public Text numberOfEnemy;


    private Transform enemies;
    private Transform player;
    private Transform enemiesPosition;
    private Transform playerPosition;


    // Use this for initialization
    void Start () {
        enemies = GameObject.Find("Enemies").transform;
        player = GameObject.Find("Player").transform;
        enemiesPosition = transform.GetChild(0);
        playerPosition = transform.GetChild(1);

    }
	
	// Update is called once per frame
	void Update () {

        int num = enemies.childCount;
        numberOfEnemy.text = num.ToString();


        foreach (Transform child in enemiesPosition)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in enemies)
        {
            Vector3 distance = child.position - player.position;
            GameObject x = (GameObject)Instantiate(enemyPoint, playerPosition.position + distance, Quaternion.identity);
            x.transform.SetParent(enemiesPosition.transform);
        }
    }
}
