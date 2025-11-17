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
        Destroy(gameObject, lifetime); // auto self-destruct
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        Debug.Log("LifePowerup hit: " + whatDidIHit.tag);

        if (whatDidIHit.tag == "Player")
        {
            // Check GameManager lives instead of player
            if (gameManager.lives < 3)
            {
                gameManager.lives++;
                gameManager.ChangeLivesText(gameManager.lives);
            }
            else
            {
                // Full health → give score instead
                gameManager.AddScore(1);
            }

            Destroy(this.gameObject);
        }
    }
}
