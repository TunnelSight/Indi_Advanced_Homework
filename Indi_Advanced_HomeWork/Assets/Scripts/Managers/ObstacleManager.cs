using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;  // ������ ��ֹ� ������

    public readonly float defaultSpawnInterval = 0.1f; // ��ֹ� ���� ����

    public float spawnPosX = 0.0f;        // ��ֹ��� X ��ǥ
    public float minZ = -10.0f;        // ��ֹ��� Z ��ǥ ���� (�ּҰ�)
    public float maxZ = 10.0f;         // ��ֹ��� Z ��ǥ ���� (�ִ밪)

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