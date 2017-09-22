using UnityEngine;
using System.Collections;

public class CameraBehaviours : MonoBehaviour {
    private GameObject player;
    public Transform top;
    public Transform down;
    public Transform left;
    public Transform right;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float size;
    // Use characterData for initialization
    void Start () {
        player = GameObject.Find("Player");
        size = gameObject.GetComponent<Camera>().orthographicSize;
        minX = left.position.x + size* gameObject.GetComponent<Camera>().aspect;
        maxX = right.position.x - size * gameObject.GetComponent<Camera>().aspect;
        minY = down.position.y + size;
        maxY = top.position.y - size;

        //For Phone
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WP8Player)
            GameObject.Find("Buttons for Phone Only").transform.GetChild(0).gameObject.SetActive(true);
        else
            GameObject.Find("Buttons for Phone Only").transform.GetChild(0).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);
        transform.position = new Vector3(x,y,transform.position.z);
    }
}
