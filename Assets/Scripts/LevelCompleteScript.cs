using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
	public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.GetComponent<PlayerController>())
		{
			anim.SetBool("isTeleporting", true);
			SceneManager.LoadScene("Level2");
		}
	}
}
