using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;  // 생성할 장애물 프리팹

    public readonly float defaultSpawnInterval = 0.1f; // 장애물 생성 간격

    public float spawnPosX = 0.0f;        // 장애물의 X 좌표
    public float minZ = -10.0f;        // 장애물의 Z 좌표 범위 (최소값)
    public float maxZ = 10.0f;         // 장애물의 Z 좌표 범위 (최대값)

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnPosZ = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(spawnPosX, 0.5f, spawnPosZ);

            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(defaultSpawnInterval * Random.Range(0.8f, 1.2f));
        }
    }
}
