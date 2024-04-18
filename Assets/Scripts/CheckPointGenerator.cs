using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class CheckPointGenerator : MonoBehaviour
{
    public NavMeshAgent agent;
    bool generate = false;
    public GameObject checkpoint;
    public int stopNow;
    int count;
    public GameObject[] goalies = { };
    int id;
    int checkpointCounter = 0;
    // Update is called once per frame
    private void Awake()
    {
        for (int i = 0; i < goalies.Length; i++)
        {
            string bPointName = "BPoint";
            if (i > 0)
            {
                bPointName += " (" + i + ")";
            }
            goalies[i] = GameObject.Find(bPointName);
            if (goalies[i] == null)
            {
                Debug.LogError("BPoint " + bPointName + " not found!");
                // Handle error if BPoint not found
            }
        }
    }
    private void Start()
    {

        id = CarSpawn.id;
        Debug.Log("MON ID ON SPAWN: "+ id);
        id = CarSpawn.id2;
        Debug.Log("JE go vers: " + id);
        
    }
    private void FixedUpdate()
    {
        Debug.Log("GO VERS PTN DE ID: "+id);
       CheckpointGeneration(goalies[id]);
        
    }

    public void CheckpointGeneration(GameObject goal)
    {
        
        agent.SetDestination(goal.transform.position);
        count++;
        if (count >= 20)
        {
            Vector3 pos = transform.position;
            GameObject checkObject = Instantiate(checkpoint, pos, transform.rotation);
            checkObject.name = this.name+ " " + checkpointCounter;
            checkpointCounter++;
            count = 0;

        }
       
        if(Vector3.Distance(goal.transform.position, transform.position) < stopNow)
        {
            
            agent.isStopped = true;
            Destroy(gameObject, 1f);
        }
    }
}
