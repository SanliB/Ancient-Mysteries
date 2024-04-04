using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoSingleton<SoundManager>
{
    private AudioSource audioSource;

    [SerializeField] 
    private AudioClip[] _audio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    public void Audio(int a,float Volume)
    {
        audioSource.volume = Volume;
        audioSource.PlayOneShot(_audio[a]);
    }
}
