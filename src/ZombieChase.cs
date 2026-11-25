using UnityEngine;
using UnityEngine.AI;

public class ZombieChase : MonoBehaviour
{
    public Transform target; // XR Origin (the object the zombie will chase)
    public float chaseDistance = 10f; // Distance at which the zombie starts chasing
    public AudioSource bgmSource; // Background music source to play when chasing

    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private bool bgmPlayed = false; // Flag to check if BGM has been played

   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.radius = 0.2f; 
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
        agent.speed = 1.3f; 
        if (bgmSource != null) bgmSource.Stop(); // Stop BGM at the start
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); // Calculate distance to target

        if (distance <= chaseDistance) // If within chase distance
        {
            agent.SetDestination(target.position); // Set the agent's destination to the target

            if (!bgmPlayed && bgmSource != null) // Play BGM if not already played
            {
                bgmSource.Play();
                bgmPlayed = true;
            }
        }
        else // If out of chase distance
        {
            if (bgmPlayed && bgmSource != null) // Stop BGM if it was playing
            {
                bgmSource.Stop();
                bgmPlayed = false;
            }
        }
    }
}
