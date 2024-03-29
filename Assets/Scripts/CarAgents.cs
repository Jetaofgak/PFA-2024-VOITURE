using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.Timeline;

public class CarAgents : Agent
{
    [SerializeField] TrackCheckpoints trchecks;
    [SerializeField] Transform checkTransform;
    private WheelController controller;
    private void Start()
    {
        controller = GetComponent<WheelController>();
    }
    public override void OnActionReceived(ActionBuffers actions)
    { 
        float goLeftOrRight = actions.ContinuousActions[0];  
        if(goLeftOrRight != 0)
        {
            controller.LeftRightBool = true;
            controller.LeftOrRightDir = goLeftOrRight;
        }
        switch (actions.DiscreteActions[0])
        {
            case 0 : controller.Lbreak = true; break;
            case 1 : controller.breaking = true; break;
            case 2 : controller.Fbreak = true; break;
            case 3 : controller.Fbreak = false; controller.breaking = false; controller.Lbreak = false; break;

        }

        switch (actions.DiscreteActions[1])
        {
            case 0: controller.UpDownBool = true;controller.UpOrDownDir = 1;  break;
            case 1: controller.UpDownBool = true;controller.UpOrDownDir = -1;  break;
            case 2: controller.UpDownBool = false;  break;
        }
         
        
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        
        int actionMove = 2;

        int actionbreak = 3;
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        ActionSegment<int> linearActions = actionsOut.DiscreteActions;
        continuousActions[0] = Input.GetAxis("Horizontal");
        if(Input.GetAxisRaw("Vertical")== 1)
        {

            actionMove = 0;
        }
        else if(Input.GetAxisRaw("Vertical") == -1)
        {
            actionMove = 1;
        }
        else
        {
            actionMove = 2;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            actionbreak = 0;
        }
        else if (Input.GetKey(KeyCode.B))
        {
            actionbreak = 2;
        }
        else if(Input.GetKey(KeyCode.C))
        {
            actionbreak = 1;
        }
        else
        {
            actionbreak = 3;
        }


        linearActions[0] = actionbreak;
        linearActions[1] = actionMove;
        
        
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(transform.localRotation.y);
        sensor.AddObservation(checkTransform.position);
    }
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(-5.27082253f, 9.92000008f, -27.6100006f);
        transform.localRotation = Quaternion.identity;


    }

    public void OnInfraction()
    {

    }
}
