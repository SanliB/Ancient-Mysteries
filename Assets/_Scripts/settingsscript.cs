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
        musicSlider.value = PlayerPrefs.GetFloat("musicvolume");
        audioSlider.value = PlayerPrefs.GetFloat("generalvolume");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void getvolume()
    {
        PlayerPrefs.SetFloat("musicvolume", musicSlider.value);
        audioSource.volume = musicSlider.value;
    }

    public void getGeneralVolume()
    {
        PlayerPrefs.SetFloat("generalvolume", audioSlider.value);
    }

    public void ifclickcomebackbuttonformainmenu()
    {
        SceneManager.LoadScene(3);
    }
}
