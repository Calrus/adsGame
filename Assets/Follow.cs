using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothness = 0.5f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position for the camera
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);

            // Smoothly interpolate between the current position and the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        }
    }
}