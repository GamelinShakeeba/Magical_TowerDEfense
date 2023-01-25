using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	public Button PauseBtn;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle()
    {
		FindObjectOfType<AudioManager>().Play("Button");
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
			PauseBtn.interactable = false;
		}
		else
		{
			Time.timeScale = 1f;
			PauseBtn.interactable = true;
		}
	}

    public void Retry()
    {
		FindObjectOfType<AudioManager>().Play("Button");
		Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
		
	}

    public void Menu()
    {
		FindObjectOfType<AudioManager>().Play("Button");
		Toggle();
        sceneFader.FadeTo(menuSceneName);
	}

	public void ButtonClick()
    {
		FindObjectOfType<AudioManager>().Play("Button");
	}
}
