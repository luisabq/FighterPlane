using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    private GameManager gameManager;

    public float lifetime = 6f; // auto-destroy after a while

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.PlaySound(1);
            PlayerController player = other.GetComponent<PlayerController>();
            player.ActivateShield();
            Destroy(gameObject);
        }
    }
}
