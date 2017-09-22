using UnityEngine;
using System.Collections;

public class BulletBehaviours : MonoBehaviour
{
    public int damge;
    public float destoyTime;
    void Start()
    {
        Destroy(gameObject, destoyTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Attacked(damge, 0);
            Destroy(gameObject);
        }
    }
}
