using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthAffected : MonoBehaviour
{
    public int heartsCount;
    public GameObject[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        heartsCount = hearts.Length;
    }

    public void Health()
	{
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < heartsCount)
            {
                hearts[i].SetActive(true);
                Debug.Log("health: " + heartsCount);
            }
            else
			{
                hearts[i].SetActive(false);
            }
        }
	}

	
}
