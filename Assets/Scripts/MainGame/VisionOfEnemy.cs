using UnityEngine;
using System.Collections;

public class VisionOfEnemy : MonoBehaviour {
    public int typeOfEnemy;
    private Enemy enemy;
    private float moveSpeed;
	// Use this for initialization
	void Start () {
        enemy = transform.parent.GetComponent<Enemy>();
        moveSpeed = enemy.moveSpeed;
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (typeOfEnemy == 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                enemy.moveSpeed = moveSpeed * 2;
            }
        }
        if (typeOfEnemy == 1)
        {
            if (other.gameObject.CompareTag("Player"))
                enemy.Shoot();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (typeOfEnemy == 0)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                enemy.moveSpeed = moveSpeed;
            }
        }
    }
}
