using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    public ParticleSystem destroyEffect;

    void OnTriggerEnter(Collider other)
    {
        if (destroyEffect != null)
        {
            ParticleSystem effect = Instantiate(destroyEffect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
        Destroy(other.gameObject);
    }
}
