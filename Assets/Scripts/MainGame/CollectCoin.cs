using UnityEngine;
using System.Collections;

public class CollectCoin : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().money += 1;
        }
    }

    void Update()
    {
        if (transform.position.y <= -100)
            Destroy(gameObject);
    }
}
