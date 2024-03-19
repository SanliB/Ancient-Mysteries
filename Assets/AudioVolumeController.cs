using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeController : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update7

    private void Awake()
    {
        audio.volume = PlayerPrefs.GetFloat("musicvolume");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
