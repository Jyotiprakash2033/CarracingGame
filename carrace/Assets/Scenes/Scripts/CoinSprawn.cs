using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSprawn : MonoBehaviour
{
    public GameObject coinPrefab;    // The coin prefab
    public int numberOfCoins = 10;   // The number of coins to generate
    public float spawnRange = 10f;   // The range in which coins will spawn (x and z coordinates)

    void Start()
    {
        // Call the function to spawn coins
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            // Generate a random position within the spawn range
            float x = Random.Range(-spawnRange, spawnRange);
            float z = Random.Range(-spawnRange, spawnRange);
            Vector3 spawnPosition =transform.position+ new Vector3(x, 0, 0); // Adjust the Y value to place the coin on the ground
          Quaternion rotation = Quaternion.Euler(0, 0, 90);

            // Instantiate the coin at the generated position
            Instantiate(coinPrefab, spawnPosition, rotation);
        }
    }
}