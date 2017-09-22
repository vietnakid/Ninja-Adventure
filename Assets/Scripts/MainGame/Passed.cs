using UnityEngine;
using System.Collections;

public class Passed : MonoBehaviour {
    public int mapLevel;
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
	void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.Find("Enemies").transform.childCount == 0)
            player.Sync(mapLevel);
    }
}
