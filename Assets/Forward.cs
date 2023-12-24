using UnityEngine;

public class AutoForwardMovement : MonoBehaviour
{
    public float forwardSpeed = 5.0f;

    void Update()
    {
        // Get the current position of the player
        Vector3 currentPosition = transform.position;

        // Move the player forward automatically in the world space
        currentPosition += Vector3.forward * forwardSpeed * Time.deltaTime;

        // Set the updated position
        transform.position = currentPosition;
    }
}
