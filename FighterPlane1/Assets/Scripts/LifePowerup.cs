using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerup : MonoBehaviour
{
    private GameManager gameManager;

    public float lifetime = 3f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Destroy if untouched for lifetime duration
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        // Only act if the player touches it
        if (whatDidIHit.CompareTag("Player"))
        {
            // If player has less than 3 lives, add one
            if (gameManager.lives < 3)
            {
                gameManager.AddLife();
            }
            else
            {
                // Full health → give score instead
                gameManager.AddScore(1);
            }

            Destroy(this.gameObject); // destroy power-up on pickup
        }
    }   
}
