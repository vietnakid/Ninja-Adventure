using UnityEngine;
using System.Collections;

public class KnifeBehaviour : MonoBehaviour
{
    private int damge;
    private float direction;
    void Start()
    {
        damge = GameObject.Find("Player").GetComponent<Player>().power/2 + GameObject.Find("Player").GetComponent<Player>().damge/2;
        direction = GameObject.Find("Player").GetComponent<Player>().direction;
        Destroy(gameObject, 1);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
            other.gameObject.GetComponent<Enemy>().Attacked(damge, direction);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("EnemyWeapon"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
