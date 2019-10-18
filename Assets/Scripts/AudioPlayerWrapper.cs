using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerWrapper : MonoBehaviour
{
    public AudioSource _audioSource;

    void Start()
    {
        // find the player audio source
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volumeScale = 1.0f)
    {
        _audioSource.PlayOneShot(clip, volumeScale);
    }
}
