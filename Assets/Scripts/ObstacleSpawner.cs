using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacles In This Segment")]
    public List<GameObject> obstaclePool = new List<GameObject>();

    [Header("Difficulty Settings")]
    public float difficultyIncreaseTime = 15f;

    [Header("Chance Settings")]
    public int startingThreshold = 50;
    public int thresholdDecreaseAmount = 5;
    public int minimumThreshold = 20;

    private static int currentThreshold;
    private static float timer;

    private static bool initialized = false;

    void Start()
    {
        // Initialize ONLY ONCE globally
        if (!initialized)
        {
            currentThreshold = startingThreshold;
            initialized = true;
        }

        // Turn all obstacles off first
        foreach (GameObject obstacle in obstaclePool)
        {
            obstacle.SetActive(false);
        }

        ActivateObstacles();
    }

    void Update()
    {
        // Shared global difficulty timer
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

    void ActivateObstacles()
    {
        int activateCounter = 0;

        // Roll once per obstacle slot
        for (int i = 0; i < obstaclePool.Count; i++)
        {
            int randomValue = Random.Range(1, 101);

            if (randomValue > currentThreshold)
            {
                activateCounter++;
            }
        }

        // Copy list
        List<GameObject> availableObstacles =
            new List<GameObject>(obstaclePool);

        // Activate random obstacles
        for (int i = 0; i < activateCounter; i++)
        {
            if (availableObstacles.Count <= 0)
                break;

            int randomIndex =
                Random.Range(0, availableObstacles.Count);

            availableObstacles[randomIndex].SetActive(true);

            availableObstacles.RemoveAt(randomIndex);
        }
    }
}