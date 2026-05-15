using UnityEngine;
using System.Collections.Generic;

public class SegmentManager : MonoBehaviour
{
    [Header("Path Prefabs")]
    public GameObject prefabA;
    public GameObject prefabB;

    [Header("Player")]
    public Transform player;

    [Header("Settings")]
    public int tilesOnScreen = 10;

    private Queue<GameObject> activeTiles = new Queue<GameObject>();

    private Transform lastEndPoint;

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z > lastEndPoint.position.z - 500f)
        {
            SpawnTile();

            if (activeTiles.Count > tilesOnScreen + 1)
            {
                DeleteOldTile();
            }
        }
    }

    void SpawnTile()
    {
        GameObject prefabToSpawn =
            Random.Range(0, 2) == 0 ? prefabA : prefabB;

        Vector3 spawnPosition = Vector3.zero;

        if (lastEndPoint != null)
        {
            spawnPosition = lastEndPoint.position;
        }

        GameObject tile = Instantiate(
            prefabToSpawn,
            spawnPosition,
            Quaternion.identity
        );

        // Find points
        Transform startPoint = tile.transform.Find("StartPoint");
        Transform endPoint = tile.transform.Find("EndPoint");

        // Align StartPoint to previous EndPoint
        if (lastEndPoint != null)
        {
            Vector3 offset = tile.transform.position - startPoint.position;
            tile.transform.position = lastEndPoint.position + offset;
        }

        // Store new endpoint
        lastEndPoint = endPoint;

        activeTiles.Enqueue(tile);
    }

    void DeleteOldTile()
    {
        GameObject oldTile = activeTiles.Dequeue();
        Destroy(oldTile);
    }
}