using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float screenWidth = 16f;
    public Text foodCounterText;

    private int foodCount = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get mouse position in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Limit the player's movement to the x-axis only
        Vector3 newPos = new Vector3(mousePos.x, transform.position.y, 0);

        // Limit the player's movement to the screen width
        newPos.x = Mathf.Clamp(newPos.x, -screenWidth / 2f, screenWidth / 2f);

        // Move the player towards the new position
        rb.MovePosition(Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "uvas" && other.gameObject.layer == LayerMask.NameToLayer("food"))
        {
            Destroy(other.gameObject);
            foodCount++;
            foodCounterText.text = "Comida: " + foodCount;
        }
    }
}
