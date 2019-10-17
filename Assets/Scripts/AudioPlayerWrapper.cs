using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerWrapper : MonoBehaviour
{
    public AudioSource _audioSource;

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

    /* This is sample code for implementing "play sound, wait for finish and then continue"
     *  type functionality. Must be in the object it is needed in for correct scope
    private IEnumerator coroutine;
    public void PlaySoundAndWait(AudioClip clip, float volumeScale = 1.0f)
    {
        PlaySound(clip, volumeScale);
        coroutine = WaitForClipLength(clip);
        StartCoroutine(coroutine);
    }
    private IEnumerator WaitForClipLength(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
        // the rest of the code that needs executed after the clip is finished
    }
    */
}
