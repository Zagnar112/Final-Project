using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePool = new List<GameObject>();
    // Add your 10 inactive obstacles here

    [Header("Difficulty Settings")]
    public float difficultyIncreaseTime = 15f;

    [Header("Chance Settings")]
    public int startingThreshold = 50;
    public int thresholdDecreaseAmount = 5;
    public int minimumThreshold = 20;

    private int currentThreshold;
    private float timer;

    void Start()
    {
        currentThreshold = startingThreshold;

        // Make sure all obstacles start inactive
        foreach (GameObject obstacle in obstaclePool)
        {
            obstacle.SetActive(false);
        }

        ActivateObstacles();
    }

    void Update()
    {
        // Increase difficulty over time
        timer += Time.deltaTime;

        if (timer >= difficultyIncreaseTime)
        {
            timer = 0f;

            currentThreshold -= thresholdDecreaseAmount;

            if (currentThreshold < minimumThreshold)
            {
                currentThreshold = minimumThreshold;
            }

            Debug.Log("New Threshold: " + currentThreshold);
        }
    }

    // Call this whenever a new track segment appears
    public void ActivateObstacles()
    {
        int activateCounter = 0;

        // FIRST LOOP
        // Roll 10 times
        for (int i = 0; i < 10; i++)
        {
            int randomValue = Random.Range(1, 101);

            if (randomValue > currentThreshold)
            {
                activateCounter++;
            }
        }


        // TEMP INDEX LIST
        List<GameObject> availableObstacles =
            new List<GameObject>(obstaclePool);

        // Turn everything OFF first
        foreach (GameObject obstacle in obstaclePool)
        {
            obstacle.SetActive(false);
        }

        // SECOND LOOP
        for (int i = 0; i < activateCounter; i++)
        {
            // Stop if nothing remains
            if (availableObstacles.Count <= 0)
                break;

            // Pick random remaining obstacle
            int randomIndex =
                Random.Range(0, availableObstacles.Count);

            // Activate selected obstacle
            availableObstacles[randomIndex].SetActive(true);

            // Remove used obstacle
            availableObstacles.RemoveAt(randomIndex);
        }
    }
}