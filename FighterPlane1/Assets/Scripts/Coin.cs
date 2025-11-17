using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 5f; // coin will disappear automatically
    public int scoreValue = 1;

    void Start()
    {
        // Auto-destroy coin after lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
