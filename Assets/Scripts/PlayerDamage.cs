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
    public Transform playerTransform;
    private FallCheck fallCheck;

	private void Start()
	{
        fallCheck = GetComponent<FallCheck>();
	}

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
        //enemyAnim.SetTrigger("isAttacking");
        playerAnim.SetTrigger("isHit");
        playerTransform.transform.Translate(Vector3.back * Time.deltaTime);
        HealthDecreased();
    }

    public void PlayerDead()
	{
        playerAnim.SetTrigger("isDead");
        this.enabled = false;
        gameOverController.PanelActive();
    }
    
    public void HealthDecreased()
	{
        healthAffected.heartsCount--;
        healthAffected.Health();
    }

}
