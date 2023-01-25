using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   // public string levelToLoad = "Game";

    public SceneFader sceneFader;
    public GameObject controlPanel;

    void Awake()
    {
        controlPanel.gameObject.SetActive(false);
    }

    public void Play()
    {
        sceneFader.FadeTo("Game");
        FindObjectOfType<MenuSound>().Play("Button");
    }

    public void ControlBtn()
    {
        controlPanel.gameObject.SetActive(true);
        FindObjectOfType<MenuSound>().Play("Button");
    }

    public void OkBtn()
    {
        controlPanel.gameObject.SetActive(false);
        FindObjectOfType<MenuSound>().Play("Button");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
        FindObjectOfType<MenuSound>().Play("Button");
    }
}
