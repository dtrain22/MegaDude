using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private static AudioSource playerAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        Debug.Log("playerAudioSource initialized");
    }

    public static void PlaySound(AudioClip clip, float volumeScale = 1.0f)
    {
        Debug.Log("playing a sound!");
        playerAudioSource.PlayOneShot(clip, volumeScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
