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

    public TextMeshProUGUI livesText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;

        CreateSky();

        // Enemy One spawns starting early and more frequently
        InvokeRepeating("CreateEnemyOne", 1, 2);

        // Enemy Two spawns later and less frequently
        InvokeRepeating("CreateEnemyTwo", 1, 3);

        // Enemy Three spawns later and less frequently
        InvokeRepeating("CreateEnemyThree", 2, 5);
    }

    void Update()
    {
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab,new Vector3(Random.Range(-8f, 8f), 6.5f, 0),Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab,new Vector3(Random.Range(-8f, 8f), 6.5f, 0),Quaternion.identity);
    }

    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab,new Vector3(Random.Range(-8f, 8f), 6.5f, 0),Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize),0), Quaternion.identity);
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
}
