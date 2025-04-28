using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;
using Unity.VisualScripting.FullSerializer;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] clips;
    AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClip(int clipNumber)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clips[clipNumber], 0.7f);
    }
    public void StopClip()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
