using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIScript : MonoBehaviour
{
	public void StartLevel()
	{
		SceneManager.LoadScene("Level1");
	}

	public void Options()
	{

	}

	public void Quit()
	{
		Debug.Log("Application Closed");
		Application.Quit();
	}
}
