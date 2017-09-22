using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMaps : MonoBehaviour {
    private CharacterData characterData;
	// Use this for initialization
	void Start () {
        characterData = GameObject.Find("MainData").GetComponent<CharacterData>();

        int i = 0, num = characterData.getMapPassed();
	    foreach(Transform child in transform)
        {
            i++;
            if (i <= num)
            {
                child.GetComponent<Button>().enabled = true;
                foreach (Transform childDown in child)
                    childDown.gameObject.SetActive(false);
            }
            else
            {
                child.GetComponent<Button>().enabled = false;
                foreach (Transform childDown in child)
                    childDown.gameObject.SetActive(true);
            }
        }
	}
	
}
