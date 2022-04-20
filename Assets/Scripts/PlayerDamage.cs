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
    private PlayerController playerController;
    private bool isCooling = false;

    /*
     * 
                if(playerHit == true)
				{
                    PlayerHit();
                    playerHit = false;
                    StartCoroutine(Cooldown());
                }
    */
    private void Start()
	{
        fallCheck = GetComponent<FallCheck>();
        playerController = GetComponent<PlayerController>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.GetComponent<EnemyPatrol>())
        {
            heartsRemaing = healthAffected.heartsCount;
            if (heartsRemaing > 0)
            {
                if (isCooling == false)
                {
                    PlayerHit();
                    playerHit = true;
                    StartCoroutine(Cooldown());
                    isCooling = true;
                }
            }
            else
            {
                PlayerDead();
            }
        }
        playerHit = false;
    }

    private IEnumerator Cooldown()
	{
        yield return new WaitForSeconds(2f);
        isCooling = false;
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
        playerController.enabled = false;
        gameOverController.PanelActive();
        
    }
    
    public void HealthDecreased()
	{
        healthAffected.heartsCount--;
        healthAffected.Health();
    }

}
