using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	public Text roundsText;

    void OnEnable()
    {
		roundsText.text = PlayerStats.Rounds.ToString();
    }

    void Start()
    {
		FindObjectOfType<AudioManager>().Play("GameOver");
    }

    public void Retry()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
		FindObjectOfType<AudioManager>().Play("Button");
	}

	public void Menu()
	{
		sceneFader.FadeTo(menuSceneName);
		FindObjectOfType<AudioManager>().Play("Button");
	}

}
