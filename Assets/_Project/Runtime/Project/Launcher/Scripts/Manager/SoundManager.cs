using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource audioSource;

    [SerializeField] 
    private AudioClip[] _audio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Audio(int a)
    {
        audioSource.PlayOneShot(_audio[a]);
    }
}
