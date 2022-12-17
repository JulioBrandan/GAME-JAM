using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruyeloquesobra : MonoBehaviour
{
    // The collider of the game object
    private Collider2D collider;

    void Start()
    {
        // Get the collider of the game object
        collider = GetComponent<Collider2D>();

        // Make sure the collider is set to trigger mode
        collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the colliding object
        Destroy(other.gameObject);
    }
}