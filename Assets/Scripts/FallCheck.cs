using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
	public new GameObject gameObject;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerController>())
		{
			Debug.Log("Player Dead");
			gameObject.transform.position = new Vector3(-5.4f, -2.6f, 3.9399f);
		}
	}
}
