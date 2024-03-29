using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider Sounds;
    public AudioSource Audio;

    public void GetAudioVolume()
    {
        Audio.volume = Sounds.value;
        //Audio.Play();

    }

    private void Start()
    {
        PlayerPrefs.SetFloat("audioVolume", Audio.volume);
    }

}
