using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        if (other.CompareTag("Obstacle"))
        {
            Obstacle obstacle = other.GetComponent<Obstacle>();
            if (obstacle != null && obstacle.sound != null)
            {
                SoundManager.instance.PlaySFX(obstacle.sound.name);
            }

            if (destroyEffect != null)
            {
                ParticleSystem effect = Instantiate(destroyEffect, other.transform.position, Quaternion.identity);
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
            }

            ObjectPool.instance.ReturnObject(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            UIManager uiManager = UIManager.instance;

            uiManager.StopTimer();
            uiManager.restartButton.gameObject.SetActive(true);
            uiManager.exitButton.gameObject.SetActive(true);
            uiManager.gameOverText.gameObject.SetActive(true);

            Destroy(other.gameObject);
            SoundManager.instance.PlaySFX("Boom");

            if (!other.GetComponent<Player>() || !other.GetComponent<Player>().dieEffectParticle) return;

            ParticleSystem effect = Instantiate(destroyEffect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
    }


}
