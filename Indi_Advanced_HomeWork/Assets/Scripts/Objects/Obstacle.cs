using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Renderer cubeRenderer;
    private float moveSpeed;
    public Sound sound;
    private void Start()
    {
        moveSpeed = Random.Range(5f, 10f);
    }
    private void OnEnable()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

}
