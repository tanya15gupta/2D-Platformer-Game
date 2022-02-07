using UnityEngine;

public class StartUIScript : MonoBehaviour
{
	public GameObject levelPanel;
	public GameObject startPanel;
	private void Awake()
	{
		startPanel.SetActive(true);
		levelPanel.SetActive(false);
	}
	public void StartLevel()
	{
		startPanel.SetActive(false);
		levelPanel.SetActive(true);
		
	}

	public void Options()
	{

	}

	public void Quit()
	{
		Application.Quit();
	}
}
