using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.Timeline;

public class CarAgents : PrometeoCarController
{
    public RayPerceptionSensorComponent3D raySensorCheckpoints;
    public RayPerceptionSensorComponent3D raySensorObstacle;
    [SerializeField] Transform checkTransform;
    public override void Initialize()
    {


    }
    private void Start()
    {
       

    }
    public override void OnActionReceived(ActionBuffers actions)
    { 
        float goLeftOrRight = actions.ContinuousActions[0];  
        if(goLeftOrRight != 0)
        {
           
        }
        switch (actions.DiscreteActions[0])
        {
           

        }

        switch (actions.DiscreteActions[1])
        {
            
        }
         
        
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        
       


       
        
        
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(transform.localRotation.y);
        sensor.AddObservation(checkTransform.position);
    }
    public override void OnEpisodeBegin()
    {
        //transform.localPosition = new Vector3(-5.27082253f, 9.92000008f, -27.6100006f);
        transform.localRotation = Quaternion.identity;


    }

    public void OnInfraction()
    {

    }
}
