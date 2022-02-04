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
    public GameOverController gameOverController;
    
	private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.GetComponent<EnemyPatrol>())
        {
            heartsRemaing = healthAffected.heartsCount;
            if (heartsRemaing > 0)
            {
                PlayerHit();
                playerHit = true;
            }
            else
            {
                PlayerDead();
            }
        }
        playerHit = false;
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
        playerAnim.SetTrigger("isDead");
        gameOverController.PanelActive();
    }
    

}
