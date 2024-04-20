using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class dontdestroyonmainaudiosource : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject secondVolume;
    private static GameObject firstVolume;
    static AudioSource temp;

    private void Awake()
    {
        if (firstVolume == null)
        {
            firstVolume = this.gameObject;
            AudioSource audioSource = firstVolume.GetComponent<AudioSource>();
            temp = audioSource;
            audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        if (this.gameObject != firstVolume)
        {
            this.gameObject.SetActive(false);
        }
        DontDestroyOnLoad(firstVolume);
    }

    public void OnClickStartOrQuit()
    {
        Destroy(firstVolume);
        firstVolume = null;
    }
    public static void changeVolume(float volume)
    {
        temp.volume = volume;
    }
}
