using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string levelName;

	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(onClick);
	}

	private void onClick()
	{
		SceneManager.LoadScene(levelName);
	}
}
