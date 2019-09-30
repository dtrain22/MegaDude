using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerWrapper : MonoBehaviour
{
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // find the player audio source
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volumeScale = 1.0f)
    {
        Debug.Log("playing a sound!");
        _audioSource.PlayOneShot(clip, volumeScale);
    }
}
