using UnityEngine;

public class FallCheck : MonoBehaviour
{
	public new GameObject gameObject;
	public PlayerDamage playerDamage;
	public Transform playerStartPoint;
	public GameObject startPoint;
	public HealthAffected healthAffected;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>())
		{
			playerDamage.HealthDecreased();
			if (healthAffected.heartsCount > 0)
			{
				playerStartPoint.transform.position = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, startPoint.transform.position.z);
			}
			else
			{
				playerDamage.PlayerDead();
			}
		}	
	}
}
