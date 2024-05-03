using System.Collections.Generic;
using UnityEngine;

public class FinalTracker : MonoBehaviour
{
    private List<CheckpointOne> checkpoints = new List<CheckpointOne>();
    private int currentCheckpointIndex = 0;
    private int numCheckpoints = 13; // Change this if the number of checkpoints changes
   

    void Start()
    {
        // Fetch all children using GetChild and add them to the list
        for (int i = 0; i < numCheckpoints; i++)
        {
            Transform checkpointTransform = transform.GetChild(i);
            CheckpointOne checkpoint = checkpointTransform.GetComponent<CheckpointOne>();
            if (checkpoint != null)
            {
                checkpoints.Add(checkpoint);
            }
        }

        // Mark the last checkpoint as final
        checkpoints[checkpoints.Count - 1].isFinal = true;
    }

    public bool DisableCrossedCheckpoints()
    {
        checkpoints[currentCheckpointIndex].gameObject.SetActive(false);
        currentCheckpointIndex++;
        return checkpoints[currentCheckpointIndex].isFinal;
        
    }
    public void EnableAllCheckpoints()
    {
        foreach (CheckpointOne checkpoint in checkpoints)
        {
            checkpoint.gameObject.SetActive(true);
        }
        currentCheckpointIndex = 0;
    }


}
