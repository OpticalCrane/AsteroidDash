using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;

    public float speed = 5f;

    void Update()
    {
        if (Keyboard.current == null)
            return;

        float move = 0;

        // Move left
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            move = -1;
        }

        // Move right
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            move = 1;
        }

        // Move spaceship
        transform.Translate(
            Vector2.right * move * speed * Time.deltaTime
        );

        // Shoot laser when spacebar is pressed
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (laserPrefab != null && firePoint != null)
            {
                Instantiate(
                    laserPrefab,
                    firePoint.position,
                    Quaternion.identity
                );
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Asteroid")
        {
            Debug.Log("Game Over");
        }
    }
}