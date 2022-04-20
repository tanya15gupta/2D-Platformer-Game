using UnityEngine;
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
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.buildIndex);
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
