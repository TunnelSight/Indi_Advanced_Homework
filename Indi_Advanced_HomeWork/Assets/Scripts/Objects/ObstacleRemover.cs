using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    public ParticleSystem destroyEffect;

    void OnTriggerEnter(Collider other)
    {
        Renderer obstacleRenderer = other.GetComponent<Renderer>();

        if (obstacleRenderer != null)
        {
            Color obstacleColor = obstacleRenderer.material.color;

            ParticleSystem.MainModule mainModule = destroyEffect.main;
            mainModule.startColor = obstacleColor;
        }

        if (destroyEffect != null)
        {
            ParticleSystem effect = Instantiate(destroyEffect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }

        Destroy(other.gameObject);
    }
}
