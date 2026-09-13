using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject obstacle;
    public GameObject boosterPrefab;
    public float verticalRange = 3f;
    public float spawnMargin = 2f;

    [Header("Timing Settings")]
    public float initialSpawnRate = 1f;
    public float minSpawnRate = 0.3f;
    [Range(0, 1)] public float boosterChance = 0.2f;
    public float speedIncreasePerMinute = 2f;

    private float nextSpawnX;

    void Start()
    {
        CalculateSpawnPosition();
        StartCoroutine(SpawnLoop());
    }

    void CalculateSpawnPosition()
    {
        nextSpawnX = Camera.main.ViewportToWorldPoint(new Vector3(1 + spawnMargin, 0, 0)).x;
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnObject();
            float difficulty = Mathf.Clamp01(Time.timeSinceLevelLoad / 60f);
            float currentRate = Mathf.Lerp(initialSpawnRate, minSpawnRate, difficulty);
            yield return new WaitForSeconds(currentRate);
        }
    }

    void SpawnObject()
    {
        CalculateSpawnPosition();
        Vector3 spawnPos = new Vector3(nextSpawnX, Random.Range(-verticalRange, verticalRange), 0);

        if (Random.value <= boosterChance)
        {
            Instantiate(boosterPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            GameObject newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);
            float speedBonus = (Time.timeSinceLevelLoad / 60f) * speedIncreasePerMinute;
            newObstacle.GetComponent<Obstacle>().speed += speedBonus;
        }

        Debug.Log("Spawning something... time = " + Time.timeSinceLevelLoad);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(new Vector3(nextSpawnX, 0, 0), new Vector3(1, verticalRange * 2, 1));
    }
}
