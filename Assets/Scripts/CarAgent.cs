using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class CarAgent : Agent
{
    private PrometeoCarController carController;
    Rigidbody rb;

    private void Awake()
    {
        // Get the PrometeoCarController component on the same GameObject
        carController = GetComponent<PrometeoCarController>();
        rb = GetComponent<Rigidbody>();
    }


    public override void OnEpisodeBegin()
    {
        GameObject parentObject = transform.parent.gameObject;
        

        FinalTracker finalTracker = parentObject.GetComponentInParent<FinalTracker>();
        rb.velocity = Vector3.zero;
        finalTracker.EnableAllCheckpoints();
        transform.localPosition = new Vector3(18, -46, -21);
        transform.localRotation = Quaternion.Euler(0, -90, 0);
        carController.frontLeftCollider.motorTorque = 0;
        carController.frontRightCollider.motorTorque = 0;
        carController.rearLeftCollider.motorTorque = 0;
        carController.rearRightCollider.motorTorque = 0;

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 0)
        {
            carController.GoForward();
            Debug.Log("FORWARD");
        }
        else if (actions.DiscreteActions[0] == 1)
        {
            carController.GoReverse();
            Debug.Log("REVERSE");
        }
        else if (actions.DiscreteActions[0] == 2)
        {
            carController.ThrottleOff();
            Debug.Log("PAS BOUGER");
        }

        if (actions.DiscreteActions[1] == 0)
        {
            carController.TurnLeft();
            Debug.Log("GAUCHE");
        }
        else if (actions.DiscreteActions[1] == 1)
        {
            carController.TurnRight();
            Debug.Log("DROITE");
        }
        else if ((actions.DiscreteActions[1] == 2))
        {
            carController.ResetSteeringAngle();
            Debug.Log("NEUTRAL");
        }
        if (actions.DiscreteActions[2] == 0)
        {
            carController.Brakes();
            Debug.Log("BREAK");
        }
        else if (actions.DiscreteActions[2] == 1)
        {
            Debug.Log("NOBREAK");

        }
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        Debug.Log("Heuristic method called");
        var discreteActions = actionsOut.DiscreteActions;

        // Reset all actions to default values
        // discreteActions.Clear();

        // Forward/backward control
        if (Input.GetKey(KeyCode.S)) // Move forward
        {
            discreteActions[0] = 0;
            Debug.Log("INPUT");
        }
        else if (Input.GetKey(KeyCode.Z)) // Move backward
        {
            discreteActions[0] = 1;
        }
        else
        {
            discreteActions[0] = 2; // Throttle off
        }

        // Left/right control
        if (Input.GetKey(KeyCode.Q)) // Turn left
        {
            discreteActions[1] = 0;
        }
        else if (Input.GetKey(KeyCode.D)) // Turn right
        {
            discreteActions[1] = 1;
        }
        else
        {
            discreteActions[1] = 2; // Reset steering angle
        }

        // Braking control
        if (Input.GetKey(KeyCode.B))
        {
            discreteActions[2] = 0; // Apply brakes
        }
        else
        {
            discreteActions[2] = 1; // Do nothing
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(transform.rotation);
    }
    public void ChangeTag(List<string> t)
    {
        carController.CheckpointSensor.DetectableTags = t;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PrometeoCarController>(out PrometeoCarController controller) || other.TryGetComponent<Mur>(out Mur mur))
        {
            AddReward(-10f);
            Debug.Log("FAILURE");
            EndEpisode();



        }
        if (other.TryGetComponent<Pieton>(out Pieton piet))
        {
            AddReward(-100f);
            Debug.Log("Super Failure");
            EndEpisode();




        }
        if (other.TryGetComponent<CheckpointOne>(out CheckpointOne checkpointOne))
        {
            GameObject parentObject = other.transform.parent.gameObject;

            // Get the FinalTracker component in the parent GameObject
            FinalTracker finalTracker = parentObject.GetComponentInParent<FinalTracker>();

            if (finalTracker.DisableCrossedCheckpoints() == false)
            {
                AddReward(10f);
                Debug.Log("PASSED");

            }
            else
            {
                AddReward(20f);
                Debug.Log("FINISHED");
                EndEpisode();
            }

        }

    }


}
