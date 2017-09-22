using UnityEngine;
using System.Collections;

public class Enemy : Character {
    public int awardExperience, awardCoinMin, awardCoinMax;
    private Player player;
    public GameObject Coin;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Move(direction);
    }

    void Dead()
    {
        Destroy(gameObject);
        player.experience += awardExperience;

        int numCoin = Random.Range(awardCoinMin, awardCoinMax);
        for (int i = 0; i < numCoin; i++)
        {
            GameObject x = (GameObject) Instantiate(Coin, transform.position, Quaternion.identity);
            x.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value*2, 3);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurnBack"))
        {
            TurnFace(-direction);
        }
    }

   

    public void ActiveAttack()
    {
        foreach (Transform child in transform)
            if (child.gameObject.CompareTag("EnemyAttack"))
                child.gameObject.SetActive(true);
    }

    public void DeActiveAttack()
    {
        foreach (Transform child in transform)
            if (child.gameObject.CompareTag("EnemyAttack"))
                child.gameObject.SetActive(false);
    }

}
