using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public Animator playerAnim;
    public Animator enemyAnim;
    public HealthAffected healthAffected;
    public int heartsRemaing;
    public bool playerHit;
    
	private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.GetComponent<PlayerController>())
        {
            heartsRemaing = healthAffected.heartsCount;
            if (heartsRemaing > 0)
            {
                PlayerHit();
                playerHit = true;
                Debug.Log("Player hit is true" + playerHit);
            }
            else
            {
                PlayerDead();
            }
        }
        playerHit = false;
        Debug.Log("Player hit is false:" + playerHit);
    }

    public void PlayerHit()
	{
        enemyAnim.SetTrigger("isAttacking");
        healthAffected.heartsCount--;
        healthAffected.Health();
        playerAnim.SetTrigger("isHit");
    }

    public void PlayerDead()
	{
        Debug.Log("player dead");
        playerAnim.SetTrigger("isDead");
        StartCoroutine(LoadLevelWait());
    }
    IEnumerator LoadLevelWait()
    {
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Level1");

    }

}
