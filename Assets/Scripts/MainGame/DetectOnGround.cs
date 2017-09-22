using UnityEngine;
using System.Collections;



public class DetectOnGround : MonoBehaviour {
    public Player player;

    // Use characterData for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (!((other.CompareTag("Enemy") || other.CompareTag("EnemyAttack") || other.CompareTag("Coin") || other.CompareTag("TurnBack"))))
            player.IsOnGround = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        player.IsOnGround = false;
    }
}
