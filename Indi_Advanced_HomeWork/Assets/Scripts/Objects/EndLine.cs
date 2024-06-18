using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    public ObstacleManager obstacleManager;

    private void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.StopTimer();
            UIManager.instance.ShowClearText();
            UIManager.instance.ShowUI();
            obstacleManager.GetComponent<ObstacleManager>().StopAllCoroutines();
            Destroy(other.gameObject);
        }
    }
}
