using UnityEngine;
using UnityEngine.SceneManagement;

public class FallCheck : MonoBehaviour
{
	public new GameObject gameObject;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>())
		{
			Debug.Log("Player Dead");
			SceneManager.LoadScene("NewScene");
		}
	}
}
