using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public List<Sound> sounds;
    public List<AudioSource> audioSources;

    void Awake()
    {
        if (instance == null) instance = this; else if (instance != null) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSources = new List<AudioSource>();
        foreach (Transform child in transform)
        {
            AudioSource audioSource = child.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSources.Add(audioSource);
            }
        }
    }

    // ��Ȱ��ȭ�� ����� �ҽ��� ã�Ƽ� ����ϱ�
    public void PlaySFX(string name)
    {
        AudioSource availableAudioSource = GetAvailableAudioSource();
        AudioClip clip = GetAudioClipByName(name);

        if (availableAudioSource != null && clip != null)
        {
            StartCoroutine(PlaySFXCoroutine(availableAudioSource, clip));
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        // ��Ȱ��ȭ�� ����� �ҽ� ã��
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                return audioSource;
            }
        }
        return null;
    }

    private AudioClip GetAudioClipByName(string name)
    {
        // �־��� �̸��� �ش��ϴ� ����� Ŭ�� ã��
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
            {
                return sound.clip;
            }
        }
        return null;
    }

    private IEnumerator PlaySFXCoroutine(AudioSource audioSource, AudioClip clip)
    {
        audioSource.gameObject.SetActive(true);

        audioSource.pitch = Random.Range(0.7f, 1.5f);
        audioSource.dopplerLevel = Random.Range(0.7f, 1.5f);

        audioSource.PlayOneShot(clip);

        yield return new WaitForSeconds(clip.length);

        audioSource.gameObject.SetActive(false);
    }

}