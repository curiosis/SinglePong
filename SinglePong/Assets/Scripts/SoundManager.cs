using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip paddle, countEnd, count;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "paddle":
                audioSource.PlayOneShot(paddle);
                break;
            case "count":
                audioSource.PlayOneShot(count);
                break;
            case "countEnd":
                audioSource.PlayOneShot(countEnd);
                break;
        }
    }
}
