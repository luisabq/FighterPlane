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

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        Debug.Log("LifePowerup hit: " + whatDidIHit.tag);

        if (whatDidIHit.tag == "Player")
        {
            PlayerController player = whatDidIHit.GetComponent<PlayerController>();

            if (player.lives < 3)
            {
                player.lives++;
                gameManager.ChangeLivesText(player.lives);
            }
            else
            {
                gameManager.AddScore(1);
            }

            Destroy(this.gameObject); // destroy on pickup
        }
    }


}
