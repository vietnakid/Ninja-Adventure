using UnityEngine;
using System.Collections;

public class MainMenuBehaviours : MonoBehaviour {
    public Camera camera;
	// Use this for initialization
	void Start () {
        float width, height;
        height = (camera.orthographicSize + 1) * 2;
        width = 1000;
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

    }
	
	public void MoveCamara(int x)
    {
        float leng = 10;
        camera.transform.position = new Vector3(Mathf.Clamp(camera.transform.position.x + x*(leng),0,1000), camera.transform.position.y, camera.transform.position.z);
    }
}
