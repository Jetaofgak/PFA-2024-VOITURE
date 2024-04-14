using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CheckPointGenerator : MonoBehaviour
{
    public NavMeshAgent agent;
    bool generate = false;
    public GameObject checkpoint;
    public Transform goal;
    public int stopNow;
    int count;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            generate = true;
            agent.SetDestination(goal.position) ;
        }

        
    }
    private void FixedUpdate()
    {
        if(generate) 
        {
            count++;
            if(count>= 20)
            {
                Vector3 pos = transform.position;
                Instantiate(checkpoint,pos,transform.rotation);
                count = 0;
                
            }
        }
        if (Vector3.Distance(goal.position, transform.position) < stopNow)
        {
            generate= false;
            agent.isStopped = true;
        }
    }
}
