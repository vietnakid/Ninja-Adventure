using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SenceManagement : MonoBehaviour {
    public void LoadScenes(string name)
    {
        if (name == "Exit")
            Application.Quit();
        else
            SceneManager.LoadScene(name);
    }

    public IEnumerator LoadScenes(int id)
    {
        fadeDir = 1;
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(id);
    }

    [SerializeField]
    private Texture2D fadeOutTexture;
    float fadeSpeed = 0.3f;

    int drawDepth = -1000;
    float alpha = 1.0f;
    float fadeDir = -1; // 1 -> fadeIn. -1 ->fadeOut

    void OnGUI()
    {
        alpha += fadeDir * Time.deltaTime * fadeSpeed;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);


        //Reset
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 1);
        if (GUI.Button(new Rect(0, 0, 100, 60), "Reset"))
            PlayerPrefs.DeleteAll();
    }
}
