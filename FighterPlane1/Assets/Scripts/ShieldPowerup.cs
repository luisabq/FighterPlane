using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public float lifetime = 6f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.ActivateShield();
            Destroy(gameObject);
        }
    }
}
