using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolingSpeed;
    private bool isGoingRight = true;
    private float enemyRaycastingDistance = 1.0f ;
    public LayerMask groundLayer;
    public Transform groundDetection;

    
    void Update()
    {
        transform.Translate(Vector2.right * patrolingSpeed * Time.deltaTime);
        CheckForWalls();
    }

    private void CheckForWalls()
    { 
        RaycastHit2D hit = Physics2D.Raycast(groundDetection.position, -transform.up, enemyRaycastingDistance, groundLayer);

        // if we hit something, check its tag and act accordingly
        if (hit.collider == false)
        {
            if (isGoingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isGoingRight = false;
            }
			else
			{
                transform.eulerAngles = new Vector3(0, 0, 0);
                isGoingRight = true;
			}
        }
    }
}
