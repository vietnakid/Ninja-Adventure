using UnityEngine;
using System.Collections;

public class PlayerAttackRange : MonoBehaviour
{
    private int damge;
    private float direction;
    private Player player;


    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        damge = player.damge;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            direction = player.direction;
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                other.gameObject.GetComponent<Enemy>().Attacked(damge, direction);
                //print(other.gameObject.name);
            }
        }
    }


    /*
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Enemy>() != null)
                if (other.gameObject.GetComponent<Enemy>().health > 0)
                {
                    other.gameObject.GetComponent<Enemy>().Regenation(damge);
                    //other.gameObject.GetComponent<Enemy>().Attacked(0, direction);
                    print("Exit" + other.gameObject.name);
                }
        }
    }*/
}
