using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CheckpointGenerator : MonoBehaviour
{
    public GameObject checkpointPrefab; // Prefab of the checkpoint
    private int spawnerID;
    private NavMeshAgent agent;
    private float timer = 0f; // Timer to keep track of time
    private float checkpointInterval = 0.5f; // Interval between checkpoint instantiations
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Verification();
    }

    public void SetSpawnerID(int id)
    {
        spawnerID = id;
        MoveToNextSpawn(CarSpawner.vectorSpawns[spawnerID]);
    }

    public void MoveToNextSpawn(Vector3 spawnPosition)
    {
        agent.SetDestination(spawnPosition);
    }

    private void Update()
    {
        // Check if the agent has reached its destination
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Destroy the generator GameObject
            Destroy(gameObject);
        }

        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to instantiate a checkpoint
        if (timer >= checkpointInterval)
        {
            // Instantiate a checkpoint
            Instantiate(checkpointPrefab, transform.position, this.transform.rotation);
            // Reset the timer
            timer = 0.1f;
        }
    }

    void Verification()
    {
        Debug.Log("VERIFICATION");
        foreach (Vector3 cars in CarSpawner.vectorSpawns)
            Debug.Log(cars);


    }
}