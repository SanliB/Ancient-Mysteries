using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;

public class ClickSound : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    public GameObject secondVolume;
    private static GameObject firstVolume;
    private static AudioSource temp;

    private void Awake()
    {
        if (firstVolume == null)
        {
            firstVolume = this.gameObject;
            
            AudioSource audioSource = firstVolume.GetComponent<AudioSource>();
            temp = audioSource;
            if (!PlayerPrefs.HasKey("audioVolume"))
            {
                PlayerPrefs.SetFloat("audioVolume",1.0f);
            }
            audioSource.volume = PlayerPrefs.GetFloat("audioVolume");
            temp = audioSource;
        }
        if (this.gameObject != firstVolume)
        {
            this.gameObject.SetActive(false);
        }
        DontDestroyOnLoad(firstVolume);
    }

    public static void PlayClickSound()
    {
        firstVolume.GetComponent<AudioSource>().Play();
    }

    public void OnClickStartOrQuit()
    {
        Destroy(firstVolume);
    }

    public static void ChangeVolume(float volume)
    {
        temp.volume = volume;
    }
}


