using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{

    public GameObject explosionPrefab;
    
    private GameManager gameManager;

    private float speed = 5f;           // Slightly slower than Enemy_1
    private float amplitude = 2f;       // How far it moves side to side
    private float frequency = 2f;       // How fast it moves side to side
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         // Sin wave movement pattern
        float newX = startPosition.x + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(newX, transform.position.y - speed * Time.deltaTime, 0);

        // Destroy if below screen
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        Debug.Log("Enemy2 hit: " + whatDidIHit.tag);
        if(whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } else if(whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(5);
            Destroy(this.gameObject);
        }
    }
}
