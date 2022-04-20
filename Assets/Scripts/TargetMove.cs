using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private List<Vector3> waypoints = new List<Vector3>();  // Hom many items you want, will show in Inspector
    public float speed;

    private int current = 0;
    private float WPradius = 1;

    private void Start()
    {
        GetRandom();
    }

    private void Update()
    {
        MoveBetweenWaypoints();
    }

    private void GetRandom()
    {
        for (int i = 0; i < 30; i++)
        {
            waypoints.Add(new Vector3(Random.Range(transform.position.x, transform.position.x + 3f),
                Random.Range(transform.position.y, transform.position.y + 3f),
                transform.position.z));
        }
    }

    private void MoveBetweenWaypoints()
    {
        if (Vector3.Distance(waypoints[current], transform.position) < WPradius)
        {
            current = Random.Range(0, waypoints.Count);
            if (current >= waypoints.Count)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current], Time.deltaTime * speed);
    }
}