using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    public ParticleSystem destroyEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Player"))
        {
            Renderer obstacleRenderer = other.GetComponent<Renderer>();

            if (obstacleRenderer != null)
            {
                Color obstacleColor = obstacleRenderer.material.color;

                ParticleSystem.MainModule mainModule = destroyEffect.main;
                mainModule.startColor = obstacleColor;
            }

            
            if (other.gameObject.GetComponent<Obstacle>().sound != null)
            {
                SoundManager.instance.PlaySFX(other.gameObject.GetComponent<Obstacle>().sound.name);
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
}
