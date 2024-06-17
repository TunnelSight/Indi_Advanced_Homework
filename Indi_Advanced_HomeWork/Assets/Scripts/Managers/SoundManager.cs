using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public Sound[] sounds;                      // 사운드 배열

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

    // 비활성화된 오디오 소스를 찾아서 재생하기
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
        // 비활성화된 오디오 소스 찾기
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
        // 주어진 이름에 해당하는 오디오 클립 찾기
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
        audioSource.PlayOneShot(clip);

        // 오디오 클립의 길이만큼 대기한 후 비활성화
        yield return new WaitForSeconds(clip.length);
        audioSource.gameObject.SetActive(false);
    }

}