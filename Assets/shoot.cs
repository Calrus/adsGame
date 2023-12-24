using UnityEngine;
using System.Collections;

public class AutoShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 1.0f; // Adjust the fire rate as needed
    public float bulletLifetime = 2.0f; // Adjust the bullet lifetime as needed

    void Start()
    {
        // Start the automatic firing coroutine
        StartCoroutine(AutoFire());
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Set the bullet speed
        bulletRb.velocity = firePoint.forward * bulletSpeed;

        Destroy(bullet, bulletLifetime);
    }

    public void ApplyPowerUp(float bulletSpeedMultiplier)
    {
        bulletSpeed *= bulletSpeedMultiplier;
    }
}