using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Timer")]
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRateMin;
    private float spawnTime;
    [SerializeField] private float rampUp;

    [Header("Spawn Location")]
    [SerializeField] private float spawnTop;
    [SerializeField] private float spawnBottom;
    private Vector2 spawnPos;

    [Header("Obstacles")]
    [SerializeField] private GameObject[] obstacles;

    private void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            if (spawnRate >= spawnRateMin) spawnRate -= rampUp;
            spawnTime = spawnRate;

            GameObject obs = obstacles[Random.Range(0, obstacles.Length)]; //Picks a random obstacle you assigned to the array.
            spawnPos = new Vector2(transform.position.x, Random.Range(spawnBottom, spawnTop)); //Picks a vertical spot to spawn.
            Instantiate(obs, spawnPos, Quaternion.identity); //Spawns obstacles to the right of the screen, if you placed the spawner there.
        }
    }
}
