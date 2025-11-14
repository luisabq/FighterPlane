using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;
    public GameObject cloudPrefab;
    public GameObject healthPrefab;
    private GameObject activeHealthPowerup; 

    public TextMeshProUGUI livesText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public float healthSpawnRate = 5f;

    public int score;

    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;

        CreateSky();

        // Enemy spawns
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 1, 3);
        InvokeRepeating("CreateEnemyThree", 2, 5);

        // Health Powerup spawns
        InvokeRepeating("SpawnHealth", 3f, healthSpawnRate);
    }

    void Update()
    {
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8f, 8f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-8f, 8f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-8f, 8f), 6.5f, 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
    }

    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }

    void SpawnHealth()
    {
        // Random X within screen width
        float randomX = Random.Range(-horizontalScreenSize, horizontalScreenSize);

        // Random Y in bottom half of the screen (-verticalScreenSize to 0)
        float randomY = Random.Range(-verticalScreenSize, 0f);

        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        // Destroy any existing powerup first
        LifePowerup existing = FindObjectOfType<LifePowerup>();
        if (existing != null)
            Destroy(existing.gameObject);

        // Spawn the new powerup
        Instantiate(healthPrefab, spawnPos, Quaternion.identity);
    }

}
