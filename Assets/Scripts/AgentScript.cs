using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform targetTR;
    [SerializeField] Animator anim;
    [SerializeField] float velocity;
    [SerializeField] bool useClickToMove;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Vector3 currentDestination;
    RaycastHit m_HitInfo = new RaycastHit();
    [SerializeField] int currentWaypointIndex=0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    // Start is called before the first frame update
    void Start()
    {
       
        currentDestination = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!useClickToMove)
        {
            //agent.destination = targetTR.position;
            agent.destination = currentDestination;
            if(agent.remainingDistance < .5f)
            {
                currentWaypointIndex++;
                if(currentWaypointIndex >= waypoints.Length -1)
                {
                    currentWaypointIndex = 0;
                }
                currentDestination = waypoints[currentWaypointIndex].position;
            }

        }
        velocity = agent.velocity.magnitude;
        anim.SetFloat("Speed",velocity);
    }

}
