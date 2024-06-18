using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;

    public readonly float defaultSpawnInterval = 0.1f;

    public float spawnPosX = 0.0f;
    public float minZ = -10.0f;
    public float maxZ = 10.0f;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    public IEnumerator SpawnObstacles()
    {
        while (player)
        {
            float spawnPosZ = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(spawnPosX, 0.5f, spawnPosZ);

            GameObject newObstacle = ObjectPool.instance.GetObject();
            newObstacle.transform.position = spawnPosition;
            newObstacle.transform.rotation = Quaternion.identity;
            newObstacle.transform.localScale = new Vector3(Random.Range(0.5f, 2.0f), Random.Range(0.5f, 2.0f), Random.Range(0.5f, 2.0f));

            yield return new WaitForSeconds(defaultSpawnInterval * Random.Range(0.8f, 1.2f));
        }
    }
}
