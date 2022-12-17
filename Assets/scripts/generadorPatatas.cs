using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorPatatas : MonoBehaviour
{
    public float spawnRate = 1f;
    public float spawnRangeX = 10f;
    public float minY = 10f;
    public float maxY = 15f;
    public GameObject[] prefabs;
    public GameObject player;

    private float timeSinceLastSpawn = 0f;
    private List<Vector3> usedPositions = new List<Vector3>();
    private List<int> usedIndices = new List<int>();

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > spawnRate)
        {
            SpawnPrefab();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnPrefab()
    {
        int prefabIndex = GetRandomPrefabIndex();
        Vector3 spawnPos = GetRandomSpawnPosition();
        GameObject prefab = Instantiate(prefabs[prefabIndex], spawnPos, Quaternion.identity);
        usedPositions.Add(spawnPos);
        usedIndices.Add(prefabIndex);
    }

    int GetRandomPrefabIndex()
    {
        if (usedIndices.Count == prefabs.Length)
        {
            // If all indices have been used, reset the list
            usedIndices.Clear();
        }

        int prefabIndex = Random.Range(0, prefabs.Length);

        // Check if the index has already been used
        if (usedIndices.Contains(prefabIndex))
        {
            // If it has, try again with a new random index
            return GetRandomPrefabIndex();
        }
        else
        {
            // If it hasn't, return the index
            return prefabIndex;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

        // Check if the position has already been used
        if (usedPositions.Contains(spawnPos))
        {
            // If it has, try again with a new random position
            return GetRandomSpawnPosition();
        }
        else
        {
            // If it hasn't, return the position
            return spawnPos;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Destroy" || other.gameObject == player)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}