using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public int damageAmount = 5; // Amount of damage to apply
    public float damageInterval = 1.0f; // Time interval between each damage application
    private float lastDamageTime; // Time of the last damage application

    // Start is called before the first frame update
    void Start()
    {
        lastDamageTime = -damageInterval; // Set initial time for damage interval calculation
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        // Check if the collision is with the player
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            // Check if the time since last damage is greater than the damage interval
            if (Time.time - lastDamageTime > damageInterval)
            {
                // Apply damage to the player
                GameObject collidedObject = other.gameObject;
                Core objectCore = collidedObject.GetComponentInChildren<Core>();

                objectCore.GetCoreComponent<Combat>().Damage(damageAmount);

                lastDamageTime = Time.time; // Update the last damage time
            }
        }
    }
}
