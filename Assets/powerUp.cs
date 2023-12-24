using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float bulletSpeedMultiplier = 1.0f;
    public float fireRateMultiplier = 1.0f;
    public float numPlayers = 1.0f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AutoShooting autoShooting = other.GetComponent<AutoShooting>();
            Debug.Log("PowerUp");

            if (autoShooting != null)
            {
                // Modify the existing player's attributes
                autoShooting.bulletSpeed *= bulletSpeedMultiplier;
                autoShooting.fireRate /= fireRateMultiplier;
            //if(numPlayers > 1){
                //GameObject playerClone = Instantiate(player, transform.position, transform.rotation);
               // playerClone = player;
          //  }
          }
            
        
            Destroy(gameObject);
        }
    }
    
}
