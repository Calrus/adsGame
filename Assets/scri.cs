using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    void Start()
    {
        // Assuming your script is attached to the player GameObject itself
        Rigidbody playerRb = GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY   ;
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the player GameObject.");
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}