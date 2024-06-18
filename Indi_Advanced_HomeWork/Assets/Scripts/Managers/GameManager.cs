using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance;

    public GameObject PlayerPrefab;
    public Vector3 playerSpawnPosition;

    public ObjectPool objectPool;
    public CameraManager cameraManager;
    public ObstacleManager obstacleManager;

    private GameObject player;


    private void Awake()
    {
        if (instance == null) instance = this; else if (instance != null) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public GameObject SpawnPlayer()
    {
        player = Instantiate(PlayerPrefab, playerSpawnPosition, Quaternion.identity);
        cameraManager.playerTransform = player.transform;
        return player;
    }

    public void RemovePlayer()
    {
        if (player)
        {
            Destroy(player);
        }
    }

    public void Restart()
    {
        objectPool.DeactivatePoolObjects();
        obstacleManager.player = SpawnPlayer().transform;
        obstacleManager.StartCoroutine(obstacleManager.SpawnObstacles());
        UIManager.instance.HideUI();
        UIManager.instance.ResetTimer();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
