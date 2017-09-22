using UnityEngine;
using System.Collections;

public class InRangeToAttack : MonoBehaviour {
    private Enemy enemy;
    void Start()
    {
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.Attack();
        }
    }
}
