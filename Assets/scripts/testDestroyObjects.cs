using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDestroyObjects : MonoBehaviour
{
    // The collider of the game object
    private Collider2D collider;

    // The counter that tracks how many times the game object can destroy other objects
    public int counter = 3;

    void Start()
    {
        // Get the collider of the game object
        collider = GetComponent<Collider2D>();

        // Make sure the collider is set to trigger mode
        collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the counter is greater than zero
        if (counter > 0)
        {
            // Destroy the colliding object
            Destroy(other.gameObject);

            // Decrement the counter
            counter--;
        }
        else
        {
            // If the counter is zero or less, do not destroy the colliding object
        }
    }
}
