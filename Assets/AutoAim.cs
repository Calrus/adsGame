using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    void Update()
    {
        // Find the nearest enemy
        Transform nearestEnemy = GetNearestEnemy();

        if (nearestEnemy != null)
        {
            // Calculate the direction to the nearest enemy
            Vector3 directionToEnemy = nearestEnemy.position - transform.position;
            directionToEnemy.y = 0.0f; // Ensure the rotation is only in the horizontal plane

            // Rotate towards the enemy
            Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // If no enemy is found, rotate back to face forward
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
        }
    }

    Transform GetNearestEnemy()
    {
        // Find all objects in the scene
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Enemy"); // Assuming enemies have the "Enemy" tag

        Transform nearestEnemy = null;
        float closestDistance = float.MaxValue;

        // Iterate through all the objects to find the nearest one
        foreach (GameObject obj in allObjects)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, obj.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = obj.transform;
            }
        }

        return nearestEnemy;
    }
}
