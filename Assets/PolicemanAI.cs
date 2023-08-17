using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PolicemanAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    private int index;
    private Vector3 target;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        UpdateTarget();
    }
    void UpdateTarget()
    {
        target = waypoints[index].position;
        agent.SetDestination(target);

    }

    void NewWaypointIndex()
    {
        index++;
        if (index == waypoints.Length)
            index = 0;
        if ((index == 2) || (index == 0))
        {
            agent.speed = 6;
            animator.SetBool("IsRunning", true);
        }
        else
        { 
        agent.speed = 2;
        animator.SetBool("IsRunning", false);

        }
    }

    // Update is called once per frame
    void Update()
    { if (Vector3.Distance(transform.position, target) < 1)
        {
            NewWaypointIndex();
            UpdateTarget();

        }



        
    }
}
