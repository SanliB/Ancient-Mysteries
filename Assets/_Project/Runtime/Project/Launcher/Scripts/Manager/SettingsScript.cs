using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider Sounds;
    public AudioSource Audio;

    private void Awake()
    {
        Audio.volume = PlayerPrefs.GetFloat("audioVolume");
    }
    public void GetAudioVolume()
    {
        Audio.volume = PlayerPrefs.GetFloat("audioVolume");
        //Audio.Play();

    }

    private void Start()
    {
       // PlayerPrefs.SetFloat("audioVolume", Audio.volume);
    }

}
