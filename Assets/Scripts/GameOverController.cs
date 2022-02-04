using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

	private void Awake()
	{
		gameObject.SetActive(false);
	}
	public void PanelActive()
	{
		gameObject.SetActive(true);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene("Level1");
	}

	public void StartMenu()
	{
		SceneManager.LoadScene("StartMenu");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
