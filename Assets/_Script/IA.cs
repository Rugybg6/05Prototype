using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class IA : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    
    public Transform[] destinations;
    
    public float distanceToFollowPath = 2f;
    
    private int numberDestination = 0;

    public GameObject player;

    public float distanceToFollowPlayer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.destination = destinations[numberDestination].position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < distanceToFollowPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

     void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
    void EnemyPath()
    {
        float distance = Vector3.Distance(transform.position, destinations[numberDestination].position);
        if (distance < distanceToFollowPath)
        {
            numberDestination++;
            if (numberDestination>=destinations.Length)
            {
                numberDestination = 0;
            }
           
        }
         navMeshAgent.destination = destinations[numberDestination].position;
    }
}
