using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject rockPrefab;
    public float shootInterval = 5f;
    public float projectileSpeed = 10f;
    public int damageAmount = 70;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Make sure to set the tag for the player GameObject
        StartCoroutine(RepeatedShootRock());
    }
    IEnumerator RepeatedShootRock()
    {
        while (true)
        {
            ShootRock();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void Update()
    {
        MoveAndRotate();
    }

    void MoveAndRotate()
    {
        // Calculate the direction from the enemy to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Make the enemy rotate towards the player's position
        transform.LookAt(player);

        // Keep the enemy at its current y position (fixed in its position)
        directionToPlayer.y = 0;
    }
    void ShootRock()
    {
        GameObject rock = Instantiate(rockPrefab, transform.position, Quaternion.identity);

        Rigidbody rockRb = rock.AddComponent<Rigidbody>();
        // add collider
        SphereCollider rockCollider = rock.AddComponent<SphereCollider>();


        if (rockRb != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Apply projectile motion
            // Apply force in the upward direction for a more realistic projectile motion
            rockRb.AddForce(Vector3.up * projectileSpeed, ForceMode.VelocityChange);

            // Add forward force to simulate the direction towards the player
            rockRb.AddForce(directionToPlayer.normalized * projectileSpeed, ForceMode.VelocityChange);

            // Destroy the rock after a certain time to avoid cluttering the scene
            Destroy(rock, 5f);
        }
    }

}
