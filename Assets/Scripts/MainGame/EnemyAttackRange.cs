using UnityEngine;
using System.Collections;

public class EnemyAttackRange : MonoBehaviour
{
    private Enemy enemy;
    private int damge;
    private float direction;


    void Awake()
    {
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
        damge = enemy.damge;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            direction = enemy.direction;
            if (other.gameObject.GetComponent<Player>() != null)
                other.gameObject.GetComponent<Player>().Attacked(damge, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            direction = enemy.direction;
            if (other.gameObject.GetComponent<Player>() != null)
                if (other.gameObject.GetComponent<Player>().health > 0)
                    other.gameObject.GetComponent<Player>().Attacked(-damge + other.gameObject.GetComponent<Player>().armor, 0);
            //print("Yes" + other.gameObject);
        }
    }
}
