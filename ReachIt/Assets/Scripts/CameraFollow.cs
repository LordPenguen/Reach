using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private PlayerMovement playerMovement;

    public float initialSpeed = 2f;
    public float accelerationRate = 0.1f;
    public float maxSpeed = 20f;

    private float currentSpeed;
    private float totalDistanceMoved;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = playerMovement.HorizontalMovement;

        // Update camera speed based on player input
        if (horizontalInput == 0 || horizontalInput < 0)
        {
            // Player is standing still or moving left, update camera speed
            currentSpeed += accelerationRate * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }

        // Calculate the target position with offset
        float xOffset = 6f; // Adjust this value to control how far to the left the character is
        Vector3 targetPosition = new Vector3(target.position.x + xOffset + totalDistanceMoved, target.position.y, transform.position.z);

        // Move the camera to the right when standing still or moving left
        transform.Translate(transform.right * currentSpeed * Time.deltaTime);
        totalDistanceMoved += currentSpeed * Time.deltaTime;
        Debug.Log("Total Distance Moved: " + totalDistanceMoved);

        // Smoothly follow the target (only on Y axis)
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Check if the player has fallen behind
        if (target.position.x < transform.position.x - 1f) // Adjust the value accordingly
        {
            // Player couldn't catch up, handle death (e.g., reload level)
            // You can replace this with your own death logic
            Debug.Log("Player fell behind. Game Over!");
            // Handle player death or reset the level
            ResetCamera();
        }
    }

    private void ResetCamera()
    {
        totalDistanceMoved = 0f;
        currentSpeed = initialSpeed;
        accelerationRate = 0.1f;
        // Optionally, you can reset other camera-related parameters here
    }
}
