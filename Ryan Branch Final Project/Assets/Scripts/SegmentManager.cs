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
    public int tilesOnScreen = 20;
    public float tileLength = 20f;

    private float spawnZ = 0f;

    private Queue<GameObject> activeTiles = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z > spawnZ - (tilesOnScreen * tileLength - 20)) //makes sure the path behind the player is deleted after crossing into the next segment
        {
            SpawnTile();
            DeleteOldTile();
        }
    }

    void SpawnTile()
    {
        GameObject prefabToSpawn;

        int randomValue = Random.Range(0, 2);

        if (randomValue == 0)
        {
            prefabToSpawn = prefabA;
        }
        else
        {
            prefabToSpawn = prefabB;
        }

        GameObject tile = Instantiate(
            prefabToSpawn,
            Vector3.forward * spawnZ,
            Quaternion.identity
        );

        activeTiles.Enqueue(tile);

        spawnZ += tileLength;
    }

    void DeleteOldTile()
    {
        GameObject oldTile = activeTiles.Dequeue();
        Destroy(oldTile);
    }
}
