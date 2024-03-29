using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private WheelController wheelController;

    void Start()
    {
        // Get reference to the WheelController script
        wheelController = GetComponent<WheelController>();
    }

    void Update()
    {
        // Example usage: Call methods based on player input, etc.
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        wheelController.ForwardOrBackward(moveInput); // Call ForwardOrBackward method with input
        wheelController.LeftOrRight(turnInput); // Call LeftOrRight method with input

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wheelController.ApplyFullBreak(); // Call ApplyFullBreak method
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            wheelController.ApplyLightBreak(); // Call ApplyLightBreak method
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            wheelController.ApplyBaseBreak(); // Call ApplyBaseBreak method when Space or LeftShift key is released
        }
    }
}