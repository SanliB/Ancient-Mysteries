using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class settingsscript : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider musicSlider;
    public Slider audioSlider;
    private AudioSource audioSource;
    //public AudioListener audioListener;


    void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        audioSlider.value = PlayerPrefs.GetFloat("audioVolume");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        dontdestroyonmainaudiosource.changeVolume(musicSlider.value);
    }

    public void GetAudioVolume()
    {
        PlayerPrefs.SetFloat("audioVolume", audioSlider.value);
        ClickSound.ChangeVolume(audioSlider.value);
    }

    public void OnClickComeBackButton()
    {
        ClickSound.PlayClickSound();
        SceneManager.LoadScene(0);
    }
}
